    using System;
    using System.Collections.Generic;
    
    public class Program
    {
    	private static final List<String> curseWords = new List<String>() {"123", "abc"};
    
        public static void Main()
        {
            String input = "text to be checked with word abc";    
    
            if(isContainCurseWord(input)){
            	Console.WriteLine("Input Contains atlease one curse word");
            }else{
            	Console.WriteLine("input does not contain any curse words")
            }
    
        }
    
        public static bool isContainCurseWord(String text){
    
        	for(String curse in curseWords){
        		if(text.Contains(curse)){
        			return true;
        		}
        	}
        	return false;
    	}	
    }
