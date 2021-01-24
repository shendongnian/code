    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{		
            string[] values = { "abC" , "efg;;" , "hiz]" };
            foreach(string word in values)
             {
               int value = 1;
               string word2 = Regex.Replace(word, @"[):;.,'=-]", "").ToLower();
    		   Console.WriteLine(word2);
             }
    		
    	}
    }
