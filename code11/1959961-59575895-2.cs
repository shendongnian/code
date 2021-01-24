    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    
    class Program
    
    {
        /// <summary>
        /// Pass legth of random word you need to generate
        /// </summary>
        /// <param name="wordLength"></param>
        /// <returns></returns>
        static string RandomLetter(int wordLength)
    
        {
            string randLetter = " ";
            string randWord = " ";
    
            string[] letters = new string[26]  { " a", " b", " c", " d", " e", " f", " g", " h", " i", " j", " k", " l", " m", " n",
    
                   " o", " p", " q", " r", " s", " t", " u", " v", " w", " x" , " y", " z"};
    
            Random rnd = new Random();
    
            for (int s = 0; s < wordLength; s++)
    
            {
                //make newrandom to 26
                int newRandomNumber = rnd.Next(1, 26);
                //it finds the letter thas is associated to the number
                randLetter = letters[newRandomNumber];
                randWord += randLetter;
            }
            //it returns word without spaces
            return Regex.Replace(randWord, @"\s+", "");
        }
        
        ///Main method
        public static void Main(string[] args)
        {
            Console.WriteLine(RandomLetter(5));
        }
    
    }
