    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string mystring = "Hello user P and user z and user P again and Z and user P";
    		string replacedstring=Regex.Replace(mystring,@"P", "$");
     	    Console.WriteLine(replacedstring);
    	}
    }
