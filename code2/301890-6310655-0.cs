    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public static class Program
    {
    	public static void Main(string[] args)
    	{
    		var list = new [] { "a", "b", "c", "d" };
    		foreach (var combi in Enumerable.Repeat(list, list.Length).CartesianProduct())
    			Console.WriteLine(string.Join(" ", combi));
    	}
    
    	static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences) 
    	{ 
    		IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() }; 
    		return sequences.Aggregate( 
    				emptyProduct, 
    				(accumulator, sequence) =>  
    				from accseq in accumulator  
    				from item in sequence  
    				select accseq.Concat(new[] {item}));                
    	}
    }
