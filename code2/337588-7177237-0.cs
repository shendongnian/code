    using System;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main()
        {
    		string input = "250.00 03 350.0001 450.00 01 550.00 02";
    
    		Match match = Regex.Match(input, @"[0-9]+[/.][0-9]+", RegexOptions.IgnoreCase);
    		if (match.Success)
    		{
    			string key = match.Groups[1].Value;
    			key = string.Format({0:2}, key);
    
    			Console.WriteLine(key);
    		}
        }
    }
