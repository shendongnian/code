    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    	String term = "test";
    	String input = "This is a test";
    	String result = Regex.Replace( input, String.Join("|", term.Split(' ')), @"<b>$&</b>");
    	Console.Out.WriteLine(result);
    	}
    }
