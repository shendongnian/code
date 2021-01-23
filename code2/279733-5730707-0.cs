    using System;    
    using System.Linq;    
    using System.Collections.Generic;
    
    namespace RemoveDuplicates
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
   			
    			string[] a = new string[] 
    			{ "red", "red", "red", "blue", 
                          "green", "green", "red", "red", 
                          "yellow", "white", "white", "red", "white", "white" };
    	
    			for(int i = 0; i < a.Length; ++i)
    				if (i == a.Length-1 || a[i] != a[i+1])
    					Console.WriteLine(a[i]);
    			
    		}
    	}
    }
