    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		
            List<String> list = new List<string>();
            list.Add("Test");
            list.Add("Test Street");
            list.Add("Street work");
            list.Add("Test machine");
      
      
            List<String> products = list;
            var filtered = from String p in products
                           where p.Contains("Test") == true
                           select p;
    		// filtered contains the result
            foreach (String product in filtered)
            {
                Console.WriteLine(product);
            }
        
    	}
    }
