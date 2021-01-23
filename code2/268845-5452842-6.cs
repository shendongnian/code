    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    namespace NS
    {
    	static class Program
    	{
    		public static IEnumerable<T> SimpleShuffle<T>(this IEnumerable<T> sequence)
    		{
    			var rand = new Random();
    			return sequence.Select(i => new {i, k=rand.Next()}).OrderBy(p => p.k).Select(p => p.i);
    		}
    
    		public static void Main(string[] args)
    		{
    			var pts = from x in Enumerable.Range(0, 24)
    				from y in Enumerable.Range(0, 11)
    				select new { x, y };
    
    			foreach (var pt in pts.SimpleShuffle())
    				Console.WriteLine("{0},{1}", pt.x, pt.y);
    		}
    	}
    }
