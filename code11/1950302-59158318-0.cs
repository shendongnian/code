    using System;
    using System.Text.RegularExpressions;
    public class Program
    {
        public static void Main()
        {
		   string test = "main(volatage1, voltage2, current)   0,017   0,77    v   100  I";
           Regex regex = new Regex(@"\d+,?\d+");
        
		
		   foreach(Match match in regex.Matches(test)) {
		       Console.WriteLine(match.Value);
		   }
         }
    }
