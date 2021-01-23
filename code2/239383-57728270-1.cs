    using System;
    using System.Text.RegularExpressions;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                //Your code goes here
                Console.WriteLine(Regex.Match("anything 876.8 anything", @"\d+\.*\d*").Value);
    			Console.WriteLine(Regex.Match("anything 876 anything", @"\d+\.*\d*").Value);
    			Console.WriteLine(Regex.Match("$876435", @"\d+\.*\d*").Value);
    			Console.WriteLine(Regex.Match("$876.435", @"\d+\.*\d*").Value);
            }
        }
    }
