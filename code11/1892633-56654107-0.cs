    using System;
    using System.Linq;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		List<string> x = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
    
    		/*
             *                                                                  Begin in the label #5  
             * 001      006     011         =>  001     002     003         =>  ---     ---     ---    
             * 002      007     012         =>  004     005     006         =>  ---     001     002    
             * 003      008     013         =>  007     008     009         =>  003     004     005    
             * 004      009     014         =>  010     011     012         =>  006     007     008    
             * 005      010     015         =>  013     014     015         =>  009     010     011 ...
             * ----------------------------------------------------------------------------------------
    		 * 016							=>	016		017		018
    		 * 017							=>	019		020
    		 * 018							=>	---		---
    		 * 019							=>	---		---
    		 * 020							=>	---		---
            */
    		
    		List<string> final = new List<string>();
    
    		int firstPosition = 1;
    		int rows = 5;
    		int columns = 3;
    		
    		int labels = rows * columns;
    		int pages = x.Count() / labels + ((x.Count() % labels) == 0 ? 0 : 1);
    
    		Console.WriteLine("Total labels {0}", x.Count());
    		Console.WriteLine("Total labels per page {0}", labels);
    		Console.WriteLine("Total pages {0}", pages);
    		Console.WriteLine();
    		
    		for (int page = 0; page < pages; page++)
    		{		
    			for (int i = 0; i < columns; i++)
    			{
    				int r = rows;
    				var h = x.Skip(page * labels).Where((c, index) => index % columns == i).Take(rows).ToList();
    				foreach (var s in h)
    				{
    					final.Add(s);
    					r--;
    				}
    				for (int j = 0; j < r; j++)
    				{
    					final.Add(null);
    				}
    			}			
    		}
    
    		foreach (var s in final)
    		{
    			Console.WriteLine(s);
    		}
    
    	}
    }
