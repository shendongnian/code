    using System;
    using System.Text.RegularExpressions;
					
    public class Program
    {
    	public static void Main()
    	{
    		string str="zaeazeaze2018azeazeazeazeaze2018azezaazeazeaze4azeaze2018";
    		string regexPattern = @"2018";
    		int numberOfOccurence = Regex.Matches(str, regexPattern).Count;
    		
    		Console.WriteLine(numberOfOccurence);
    		
    	}
    }
