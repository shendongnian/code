    using System;
    using System.Text.RegularExpressions;
    
    namespace TestSplit
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			Console.WriteLine ("Hello World!");
    			
    			
    			
    			var r = new Regex(@"
                    (?<=[A-Z])(?=[A-Z][a-z]) |
                     (?<=[^A-Z])(?=[A-Z]) |
                     (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);
    			
    			
    			string s = "TodayILiveInTheUSAWithSimon";
                Console.WriteLine( "YYY{0}ZZZ", r.Replace(s, " "));
    		}
    	}
    }
