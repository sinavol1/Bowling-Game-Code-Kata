using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Game
    {
        /// <summary>
        /// As per the rules of the bowling game, a player can have 10 frames and each frame will have 2 attempts which will be used
        /// by the user to knock the pins down. Last frame will have a bonus attempt depending on the user's performance on the first
        /// 2 attempts of the 10th frame.
        /// </summary>
        #region Variables
        public static int i, j = 0, k = 1, fr_number = 1, sc = 1, total_score = 0;
        public static int[] frames = new int[21];
        public static int[] frame_counter = new int[11];
        #endregion
        /// <summary>
        /// Main method is the start up method(Execution start place) for Game kata Application
        /// </summary>
        /// <param name="args"></param>
        public static void Main(String[] args)
        {
            try
            {
                                
                while (j <= 20)
                {
                    if (j == 0 || j == 1)
                        i = 1;
                    else if (j == 2 || j == 3)
                        i = 2;
                    else if (j == 4 || j == 5)
                        i = 3;
                    else if (j == 6 || j == 7)
                        i = 4;
                    else if (j == 8 || j == 9)
                        i = 5;
                    else if (j == 10 || j == 11)
                        i = 6;
                    else if (j == 12 || j == 13)
                        i = 7;
                    else if (j == 14 || j == 15)
                        i = 8;
                    else if (j == 16 || j == 17)
                        i = 9;
                    else if (j == 18 || j == 19 || j == 20)
                        i = 10;

                    System.Console.WriteLine("enter the number of pins that were knocked down in frame " + i + " of attempt " + k + "");
                    frames[j] = Convert.ToInt32(Console.ReadLine());
                    if (j % 2 == 0 && j <= 17 && frames[j] > 10)
                    {
                        System.Console.WriteLine("!!! Pins count OutofRange / Not more than 10 pins can be knocked per frame !!! \n please re enter ");
                        j--;
                        k--;
                    }
                    else if (j % 2 == 1 && j <= 17 && frames[j] + frames[j - 1] > 10)
                    {
                        System.Console.WriteLine("!!! Pins count OutofRange / Not more than 10 pins can be knocked per frame !!! \n please re enter ");
                        j--;
                        k--;
                    }
                    if (frames[18] > 10)
                    {
                        System.Console.WriteLine("!!! Pins count OutofRange / Not more than 10 pins can be knocked per frame !!! \n please re enter ");
                        j--;
                        k--;
                    }
                    else if (frames[18] == 10)
                    {
                        frames[19] = 0;
                        System.Console.WriteLine("you have knocked down all the 10 pins in the first attempt, please enter the number of pins you have knocked down in bonus attempt of 10th frame");
                        frames[20] = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    else if (frames[19] + frames[18] > 10)
                    {
                        System.Console.WriteLine("!!! Pins count OutofRange !!! / Not more than 10 pins can be knocked per frame \n please re enter");
                        j--;
                        k--;
                    }
                    else if (frames[19] + frames[18] == 10)
                    {
                        System.Console.WriteLine("\n enter the number of pins you have knocked down in frame 10 bonus attempt");
                        frames[20] = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    if (frames[19] + frames[18] < 10 && j == 19)
                    {
                        System.Console.WriteLine("you are not allowed for bonus attempt in 10 th frame because you have scored less than 10 in 2 attempts of 10th frame");
                        frames[20] = 0;
                        break;
                    }
                    k++;
                    j++;


                    if (k >= 3 && j <= 17)
                        k = 1;
                    if (j == 18)
                        k = 1;
                }
                Game ga = new Game();
                j = 0;
                while (fr_number <= 10)
                {
                    ga.roll(frames[j]);
                    fr_number++;
                }
                int sum = 0;
                while (sc <= 10)
                {
                    System.Console.WriteLine(" Frame " + sc + " individual score is " + frame_counter[sc]);
                    sum += frame_counter[sc];
                    System.Console.WriteLine(" Total Score at the end of frame " + sc + " is  " + sum);
                    sc++;
                }

                total_score = ga.score();
                System.Console.WriteLine(" Total score at the end of all frames is " + total_score);
                System.Console.ReadKey();
            }
            catch (Exception e)
            {

                System.Console.WriteLine("There was an unusual error occured \n error description is "+e.ToString());
                System.Console.ReadKey();

            }
        }

        #region Methods


        /// <summary>
        /// This method is to calculate score for each frame 
        /// </summary>
        /// <param name="pins"></param>
        public void roll(int pins)
        {

            try
            {
                                //for caluclating frame 1 score
                if (fr_number == 1)
                {
                    if (pins == 10 && j == 0)
                    {
                        j = j + 2;
                        frame_counter[1] = 10 + frames[j] + frames[j + 1];
                    }
                    else if (pins < 10 && j == 0)
                    {
                        j++;
                        roll(frames[j] + frames[j - 1]);
                    }
                    else if (pins == 10 && j == 1)
                    {
                        j++;
                        frame_counter[1] = frames[j] + 10;
                    }
                    else if (pins < 10 && j == 1)
                    {
                        j++;
                        frame_counter[1] = frames[j - 2] + frames[j - 1];
                    }

                }
                else if (fr_number == 2)  //for caluclating frame 1 score
                {
                    if (pins == 10 && j == 2)
                    {
                        j = j + 2;
                        frame_counter[2] = 10 + frames[j] + frames[j + 1];
                    }
                    else if (pins < 10 && j == 2)
                    {
                        j++;
                        roll(frames[j] + frames[j - 1]);
                    }
                    else if (pins == 10 && j == 3)
                    {
                        j++;
                        frame_counter[2] = frames[j] + 10;
                    }
                    else if (pins < 10 && j == 3)
                    {
                        j++;
                        frame_counter[2] = frames[j - 2] + frames[j - 1];
                    }

                }
                else if (fr_number == 3)  //for caluclating frame 3 score
                {
                    if (pins == 10 && j == 4)
                    {
                        j = j + 2;
                        frame_counter[3] = 10 + frames[j] + frames[j + 1];
                    }
                    else if (pins < 10 && j == 4)
                    {
                        j++;
                        roll(frames[j] + frames[j - 1]);
                    }
                    else if (pins == 10 && j == 5)
                    {
                        j++;
                        frame_counter[3] = frames[j] + 10;
                    }
                    else if (pins < 10 && j == 5)
                    {
                        j++;
                        frame_counter[3] = frames[j - 2] + frames[j - 1];
                    }

                }
                else if (fr_number == 4)  //for caluclating frame 4 score
                {
                    if (pins == 10 && j == 6)
                    {
                        j = j + 2;
                        frame_counter[4] = 10 + frames[j] + frames[j + 1];
                    }
                    else if (pins < 10 && j == 6)
                    {
                        j++;
                        roll(frames[j] + frames[j - 1]);
                    }
                    else if (pins == 10 && j == 7)
                    {
                        j++;
                        frame_counter[4] = frames[j] + 10;
                    }
                    else if (pins < 10 && j == 7)
                    {
                        j++;
                        frame_counter[4] = frames[j - 2] + frames[j - 1];
                    }

                }
                else if (fr_number == 5)  //for caluclating frame 5 score
                {
                    if (pins == 10 && j == 8)
                    {
                        j = j + 2;
                        frame_counter[5] = 10 + frames[j] + frames[j + 1];
                    }
                    else if (pins < 10 && j == 8)
                    {
                        j++;
                        roll(frames[j] + frames[j - 1]);
                    }
                    else if (pins == 10 && j == 9)
                    {
                        j++;
                        frame_counter[5] = frames[j] + 10;
                    }
                    else if (pins < 10 && j == 9)
                    {
                        j++;
                        frame_counter[5] = frames[j - 2] + frames[j - 1];
                    }

                }
                else if (fr_number == 6)  //for caluclating frame 6 score
                {
                    if (pins == 10 && j == 10)
                    {
                        j = j + 2;
                        frame_counter[6] = 10 + frames[j] + frames[j + 1];
                    }
                    else if (pins < 10 && j == 10)
                    {
                        j++;
                        roll(frames[j] + frames[j - 1]);
                    }
                    else if (pins == 10 && j == 11)
                    {
                        j++;
                        frame_counter[6] = frames[j] + 10;
                    }
                    else if (pins < 10 && j == 11)
                    {
                        j++;
                        frame_counter[6] = frames[j - 2] + frames[j - 1];
                    }

                }
                else if (fr_number == 7)  //for caluclating frame 7 score
                {
                    if (pins == 10 && j == 12)
                    {
                        j = j + 2;
                        frame_counter[7] = 10 + frames[j] + frames[j + 1];
                    }
                    else if (pins < 10 && j == 12)
                    {
                        j++;
                        roll(frames[j] + frames[j - 1]);
                    }
                    else if (pins == 10 && j == 13)
                    {
                        j++;
                        frame_counter[7] = frames[j] + 10;
                    }
                    else if (pins < 10 && j == 13)
                    {
                        j++;
                        frame_counter[7] = frames[j - 2] + frames[j - 1];
                    }
                }
                else if (fr_number == 8)  //for caluclating frame 8 score
                {
                    if (pins == 10 && j == 14)
                    {
                        j = j + 2;
                        frame_counter[8] = 10 + frames[j] + frames[j + 1];
                    }
                    else if (pins < 10 && j == 14)
                    {
                        j++;
                        roll(frames[j] + frames[j - 1]);
                    }
                    else if (pins == 10 && j == 15)
                    {
                        j++;
                        frame_counter[8] = frames[j] + 10;
                    }
                    else if (pins < 10 && j == 15)
                    {
                        j++;
                        frame_counter[8] = frames[j - 2] + frames[j - 1];
                    }
                }

                else if (fr_number == 9)  //for caluclating frame 9 score
                {
                    if (pins == 10 && j == 16)
                    {
                        j = j + 2;
                        frame_counter[9] = 10 + frames[j] + frames[j + 1];
                    }
                    else if (pins < 10 && j == 16)
                    {
                        j++;
                        roll(frames[j] + frames[j - 1]);
                    }
                    else if (pins == 10 && j == 17)
                    {
                        j++;
                        frame_counter[9] = frames[j] + 10;
                    }
                    else if (pins < 10 && j == 17)
                    {
                        j++;
                        frame_counter[9] = frames[j - 2] + frames[j - 1];
                    }
                }
                else if (fr_number == 10)  //for caluclating frame 10 score
                {
                    if (pins == 10 && j == 18)
                    {
                        j = j + 2;
                        frame_counter[10] = 10 + frames[j];
                    }
                    else if (pins < 10 && j == 18)
                    {
                        j++;
                        roll(frames[j] + frames[j - 1]);
                    }
                    else if (pins == 10 && j == 19)
                    {
                        j++;
                        frame_counter[10] = frames[j] + 10;
                    }
                    else if (pins < 10 && j == 19)
                    {
                        j++;
                        frame_counter[10] = frames[j] + frames[j - 1] + frames[j - 2];
                    }
                }
                    return;

            }
            catch (Exception e)
            {

                System.Console.WriteLine("There was an unusual error occured \n Error Description Is \n" + e.ToString());
                Console.ReadKey();
            
            }
        }
        /// <summary>
        ///  This method is to calculate total score by combining individual frame score
        /// </summary>
        /// <returns></returns>
        public int score()//score method for caluclating total
        {
            int total = 0, cou = 1;
            while (cou <= 10)
            {
                total = total + frame_counter[cou];
                cou++;
            }
            return total;
        }
        #endregion
        
    }
}
