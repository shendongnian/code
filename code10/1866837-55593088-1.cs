    using System;
    using System.Linq;
    
    namespace DNA
    {
    	public class Program
    	{
    		public static void Main()
    		{
    			var dna = "AAGCT";
    			var reversed = new String(dna
    				.ToLower()
    				.Replace('a', 'T')
    				.Replace('t', 'A')
    				.Replace('g', 'C')
    				.Replace('c', 'G')
    				.Reverse()
    				.ToArray());
    			Console.WriteLine(reversed);
    		}
    	}
    }
