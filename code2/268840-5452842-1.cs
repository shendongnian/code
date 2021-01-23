    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    namespace NS
    {
    	static class Program
    	{
    		private readonly static System.Security.Cryptography.MD5CryptoServiceProvider hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
    
    		public static string ToMD5(this byte[] b)
    		{
    			return System.Text.Encoding.ASCII.GetString(hasher.ComputeHash(b));
    		}
    
    		public static void Main(string[] args)
    		{
    			var pts = from x in Enumerable.Range(0, 24)
    				      from y in Enumerable.Range(0, 11)
    					  select new byte[] { (byte) x, (byte) y };
    					  
    			foreach (var pt in pts.OrderBy(pt => pt.ToMD5()))
    				Console.WriteLine("(x,y) {0},{1}", pt[0], pt[1]);
    		}
    	}
    }
    	
