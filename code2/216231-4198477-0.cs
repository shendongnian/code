    using System;
    using System.Text.RegularExpressions;
     
    public class RegexTest 
    {
        public static void Main() 
        {
            Regex r = new Regex("/(\\w+)\\s+\"(\\d+)\\.+(\\d+)\""); 
            Match m = r.Match("/home   \"1020....2010\" main ");
            Console.WriteLine("$1 = " + m.Groups[1]);
            Console.WriteLine("$2 = " + m.Groups[2]);
            Console.WriteLine("$3 = " + m.Groups[3]);
        }
    }
