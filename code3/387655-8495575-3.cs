    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
    	static void Main(string[] args)
    	{
    		var tree = new List<List<List<string>>>
    		{
    			new List<List<string>>
    			{
    				new List<string> { "a", "b" },
    				new List<string> { "c" }
    			},
    			new List<List<string>>
    			{
    				new List<string> { "x", "y" }
    			}
    		};
    		IEnumerable<Tuple<string,int>> result = tree.SelectMany((L1,i) => L1.SelectMany(L2 => L2.Select(k => Tuple.Create(k,i))));
    		foreach(var si in result)
    		{
    			Console.WriteLine(si.Item1 + ' ' + si.Item2);
    		}
    	}
    }
