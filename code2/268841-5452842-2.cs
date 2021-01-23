    using System;
    using System.Linq;
    
    namespace NS
    {
    	static class Program
    	{
    		public static void Main(string[] args)
    		{
    			var pts = from x in Enumerable.Range(0, 24)
    				from y in Enumerable.Range(0, 11)
    				select new { x, y };
    
    			var rand = new Random();
    			foreach (var pt in pts.OrderBy(pt => rand.Next()))
    				Console.WriteLine("{0},{1}", pt.x, pt.y);
    		}
    	}
    }
