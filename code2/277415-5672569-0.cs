	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	namespace SO5672236
	{
		static class Program
		{
			static void Main()
			{
				// Setup your letter mappings first
				Dictionary<char,string[]> substitutions = new Dictionary<char, string[]>
				{
					{'h', new[] {"h", "H"}},
					{'e', new[] {"e", "E", "3"}},
					{'l', new[] {"l", "L", "1"}},
					{'o', new[] {"o", "O"}}
				};
				// Take your input
				const string input = "hello";
				// Get mapping for each letter in your input
				IEnumerable<string[]> letters = input.Select(c => substitutions[c]);
				
				// Calculate cortesian product
				var cartesianProduct = letters.CartesianProduct();
				// Concatenate letters
				var result = cartesianProduct.Select(x => x.Aggregate(new StringBuilder(), (a, s) => a.Append(s), b => b.ToString()));
				// Print out results
				result.Foreach(Console.WriteLine);
			}
			// This function is taken from 
			// http://blogs.msdn.com/b/ericlippert/archive/2010/06/28/computing-a-cartesian-product-with-linq.aspx
			static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
			{
				IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
				return sequences.Aggregate(
				  emptyProduct,
				  (accumulator, sequence) =>
					from accseq in accumulator
					from item in sequence
					select accseq.Concat(new[] { item }));
			}
			// This is a "standard" Foreach helper for enumerables
			public static void Foreach<T>(this IEnumerable<T> enumerable, Action<T> action)
			{
				foreach (T value in enumerable)
				{
					action(value);
				}
			}
		}
	}
