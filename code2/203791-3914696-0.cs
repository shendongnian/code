    using System;
    using System.Collections.Generic;
    
    namespace Test
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			List<string> emptyList = new List<string>();
    
    			foreach (string item in emptyList)
    			{
    				Console.WriteLine("This will not be printed");
    			}
    
    			List<string> list = new List<string>();
    
    			list.Add("item 1");
    			list.Add("item 2");
    
    			foreach (string item in list)
    			{
    				Console.WriteLine(item);
    			}
    
    			Console.ReadLine();
    		}
    	}
    }
