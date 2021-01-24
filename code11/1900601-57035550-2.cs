    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		 var data = "[0].meetingDate=2019-07-12&[0].courseId=12&[0].raceNumber=1&[0].horseCode=000000331213&[1].meetingDate=2019-07-12&[1].courseId=12&[1].raceNumber=1&[1].horseCode=000000356650";
    		 var dataRegex=data+"&";
    		 //Console.WriteLine(dataRegex);
             showMatch(dataRegex, @"(?<==)(.*?)(?=&)");
    	}
    	
    	 private static void showMatch(string text, string expr) {
             MatchCollection mc = Regex.Matches(text, expr);
             
             foreach (Match m in mc) {
                Console.WriteLine(m);
             }
          }
    }
