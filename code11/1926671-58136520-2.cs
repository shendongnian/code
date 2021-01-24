    using System;
    using System.Linq;
    using MoreLinq;
    namespace ConsoleApp1
    {
    	internal class Program
    	{
    		private static int CountDuplicateCharacters(string s)
    		{
                return s?.CountBy(c => c).Where(kvp => kvp.Value > 1).Count() ?? 0;
	    	}
    		private static void Main(string[] args)
	    	{
    			foreach (var s in new string[] { "indivisibility", "Indivisibilities", "aA11", "ABBA" })
    			{
	    			Console.WriteLine(s + ": " + CountDuplicateCharacters(s));
		    	}
    		}
    	}
    }
