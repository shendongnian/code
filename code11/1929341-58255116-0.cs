    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static IEnumerable<string> ReadLines(){
    		yield return "sachin tendulkar(*) 101";
    		yield return "rohit sharma 121";
    		yield return "sourav ganguly 83";
    		yield return "mahendra singh dhoni(*) 99";
    		yield return "virat kohli(*) 53";	
    	}
    	
    	public static void Main()
    	{
    		int highestScore = 0;
    		string lineWithHighestScore = "";
    		
    		foreach (var str in ReadLines())
    		{
    			if (false == str.Contains("*")) continue;
    			
    			var fields = str.Split(new [] {" ", "\t"}, StringSplitOptions.RemoveEmptyEntries);
    			int score = int.Parse(fields[fields.Length-1]);
    			
    			if (score > highestScore)
    			{
    				highestScore = score;
    				lineWithHighestScore = str;
    			}
    		}
    		
    		Console.WriteLine(lineWithHighestScore);
    	}
    }
