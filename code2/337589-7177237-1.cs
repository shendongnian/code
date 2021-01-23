    using System;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main()
        {
            string input = "250.00 03 350.0001 450.00 01 550.00 02";
            Match match = Regex.Match(input, @"[0-9]+[/.][0-9]+", RegexOptions.IgnoreCase);
            while (match.Success) 
            {
                string key = match.Value;
                Console.WriteLine(String.Format("{0:0.00}", Convert.ToDecimal(key, new CultureInfo("en-US"))));
                match = match.NextMatch();
            }
        }
    }
