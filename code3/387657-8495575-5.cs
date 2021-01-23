    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Foo
    {
    	public string s;
    	public Foo(string s)
    	{
    		this.s = s;
    	}
    }
    class Program
    {
    	static void Main(string[] args)
    	{
    		var tree = new List<List<List<Foo>>>
    		{
    			new List<List<Foo>>
    			{
    				new List<Foo> { new Foo("a"), new Foo("b") },
    				new List<Foo> { new Foo("c") }
    			},
    			new List<List<Foo>>
    			{
    				new List<Foo> { new Foo("x"), new Foo("y") }
    			}
    		};
    		IEnumerable<Tuple<Foo,int>> result = tree.SelectMany((L1,i) => L1.SelectMany(L2 => L2.Select(k => Tuple.Create(k,i))));
    		foreach(var si in result)
    		{
    			Console.WriteLine(si.Item1.s + ' ' + si.Item2);
    		}
    	}
    }
