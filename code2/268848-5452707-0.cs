    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    namespace NS
    {
    	static class Program
    	{
    		private static IEnumerable<T> MixSequences<T> (params IEnumerable<T>[] sequences)
    		{
    			var se = sequences.Select(s => s.GetEnumerator()).ToList();
    			try
    			{
    				while (se.All(e => e.MoveNext()))
    					foreach (var v in se.Select(e => e.Current))
    						yield return v;
    			}
    			finally
    			{ se.ForEach(e => e.Dispose()); }
    		}
    
    		public static void Main(string[] args)
    		{
    			var dict = new Dictionary<int,int>{ {1,4},{13,8},{2,1} };
    			var twin = new Dictionary<int,int>{ {71,74},{83,78},{72,71} };
    
    			Console.WriteLine("Keys: {0}", string.Join(", ", dict.Keys));
    			Console.WriteLine("Values: {0}", string.Join(", ", dict.Values));
    			Console.WriteLine("Proof of pudding: {0}", string.Join(", ", MixSequences(dict.Keys, dict.Values)));
    			Console.WriteLine("For extra super fun: {0}", string.Join(", ", MixSequences(dict.Keys, twin.Keys, dict.Values, twin.Values)));
    		}
    	}
    }
