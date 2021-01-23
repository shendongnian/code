    using System;
    using System.IO;
    using System.Linq;
    
    public static class Program
    {
    	public static void Main(string[] args)
    	{
    		File.ReadAllLines("input.txt")
    			.Select(line => 
    			{ 
    				var split = line.Split(":".ToCharArray(), 2);
    				return new { digit = split[0].Trim().Substring(0,1),
    					 chars = split[1]
    						.Split(" \t".ToCharArray())
    						.Select(s=>s.Trim())
    						.Where(s => !String.IsNullOrEmpty(s))
    						.Select(s => s[0])
    					};
    			})
    		    .SelectMany(p => p.chars.Select(ch => new { p.digit, ch }))
    			.GroupBy(p => p.ch, p => p.digit)
    			.ToList()
    			.ForEach(g => Console.WriteLine("{0}: {1}", g.Key, string.Join(" ", g)));
    	}
    }
