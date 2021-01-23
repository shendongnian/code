    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Linq;
    using System.Collections.Generic;
    
    namespace X 
    { 
    	static class Y 
    	{
    		private static bool ReadTill(this IEnumerator<char> input, string stopChars, Action<StringBuilder> action)
    		{
    			var sb = new StringBuilder();
    
    			try 
    			{
    				while (input.MoveNext())
    					if (stopChars.Contains(input.Current))
    						return true;
    					else
    						sb.Append(input.Current);
    			} finally 
    			{
    				action(sb);
    			}
    
    			return false;
    		}
    		
    
    		private static IEnumerable<IEnumerable<string>> Tokenize(IEnumerator<char> input)
    		{
    			var result = new List<IEnumerable<string>>();
    
    			while(input.ReadTill("{", sb => result.Add(new [] { sb.ToString() })) &&
    		          input.ReadTill("}", sb => result.Add(sb.ToString().Split('|')))) 
    			{
    				// Console.WriteLine("Expected cumulative results: " + result.Select(a => a.Count()).Aggregate(1, (i,j) => i*j));
    			}
    
    			return result;
    		}
    
    		public static void Main(string[] args)
    		{
    			const string data = @"{Hello|Hi|Hi-Hi} my {mate|m8|friend|friends}, {i|we} want to {tell|say} you {hello|hi|hi-hi}.";
    		    var pockets = Tokenize(data.GetEnumerator());
    
    			foreach (var result in CartesianProduct(pockets))
    				Console.WriteLine(string.Join("", result.ToArray()));
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
    }
