    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class X
    {
        private static readonly IList<int> _list = new List<int> { 1, 2, 2, 2, 3, 4, 4, 5, 5, 5, 6, 6, 7, 8, 9, 10 };
    	public static int Main(string[] args)
    	{
    		var rand = new Random();
    		var subsequences = _list.OrderBy(i => rand.Next()).GroupBy(n => n);
    
    		var attempt = Enumerable.Range(0, subsequences.Max(g => g.Count()))
    			.SelectMany(i => subsequences.SelectMany(g => g.Skip(i).Take(1)));
    		
    		Console.WriteLine("shuffled: "  + string.Join(", ", subsequences.SelectMany(g => g)));
    		Console.WriteLine("spread: " + string.Join(", ", attempt));
    
    		return 0;
    	}
    }
