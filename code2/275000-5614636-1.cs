    using System;
    using System.Text.RegularExpressions;
    using System.Linq;
    using System.Collections.Generic;
    
    namespace X 
    { 
    	static class Y 
    	{
    		static readonly Regex chunks = new Regex(@"^(?<chunk>{.*?}|.*?(?={|$))+$", RegexOptions.Compiled);
    		static readonly Regex legs = new Regex(@"^{((?<alternative>.*?)[\|}])+(?<=})$", RegexOptions.Compiled);
    
    		private static IEnumerable<String> All(this Regex regex, string text, string group)
    		{
    			return !regex.IsMatch(text) ? new [] { text } : regex.Match(text).Groups[group].Captures.Cast<Capture>().Select(c => c.Value);
    		}
    
    		public static void Main(string[] args)
    		{
    			const string data = @"{Hello|Hi|Hi-Hi} my {mate|m8|friend|friends}, {i|we} want to {tell|say} you {hello|hi|hi-hi}.";
    			var pockets = chunks.All(data, "chunk").Select(v => legs.All(v, "alternative"));
    
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
