    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main( string[] args )
        {
            string input = "Blue Cross Blue Shield 12356";
            Regex regex = new Regex("[^A-Z]");
            string output = regex.Replace(input, "");
            Console.WriteLine(output);
        }
    }
