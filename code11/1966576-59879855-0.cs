    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		 string str = "[{name:{buyerfirstname:Randy, buyermiddlename:null, buyerlastname:Johnson}, buyerfullname:Randy Johnson, businessname:null}]";
             showMatch(str, @"(?<=[:,])(.*?)(?=\}[,\]])");
    	}
    	
    	 private static void showMatch(string text, string expr) {
             MatchCollection mc = Regex.Matches(text, expr);
             string[] matches=new string[10000];
             foreach (Match m in mc) {
    			string tailored=m.Value.Trim().Replace("{","");
    			matches = Regex.Split(tailored, ","); 
    		    for(int i=0;i<matches.Length;i++)
    			{
    				Console.WriteLine(matches[i].ToString().Trim());
    			}	
             }
          }
    }
