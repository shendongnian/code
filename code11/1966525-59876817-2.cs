    using System.IO;
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
            int n;
            int k;
            string input;
            List<string> dict = new List<string>();
            List<string> res = new List<string>();
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                dict.Add(input);
            }
            dict.Sort();
            for (int i = 0; i < k; i++)
            {
                input = Console.ReadLine();
                
                // get the full pattern for the whole number
                string patternToSearch = "";
                foreach(var c in input)
                {
                    patternToSearch += GetPattern(c);
                }
                
                Console.WriteLine(patternToSearch);
            }
        }
        
        // returns the regex pattern for one number
        static string GetPattern(char c)
        {
            switch(c)
            {
                case '2': return "[abc]";
                case '3': return "[def]";
                case '4': return "[ghi]";
                case '5': return "[jkl]";
                case '6': return "[mno]";
                case '7': return "[pqrs]";
                case '8': return "[tuv]";
                case '9': return "[wxyz]";
                default: return "";
            }
        }
    }
