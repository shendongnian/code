    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    static class Extensions
    {
        public static IEnumerable<TResult> SelectConsecutive<TSource, TResult>
            (this IEnumerable<TSource> source,
             Func<TSource, TSource, TResult> selector)
        {
            using (IEnumerator<TSource> iterator = source.GetEnumerator())
            {
               if (!iterator.MoveNext())
               {
                   yield break;
               }
               TSource prev = iterator.Current;
               while (iterator.MoveNext())
               {
                   TSource current = iterator.Current;
                   yield return selector(prev, current);
                   prev = current;
               }
            }
        }
    }
    
    class Test
    {
        static void Main()
        {
            var list = new List<int> {  21,4,7,9,12,22,17,8,2,20,23 };
            
            foreach (var sequence in FindSequences(list).Where(x => x.Item1 >= 3))
            {
                Console.WriteLine("Found sequence of length {0} starting at {1}",
                                  sequence.Item1, sequence.Item2);
            }
        }
    
        private static readonly int?[] End = { null };
        
        // Each tuple in the returned sequence is (length, first element)
        public static IEnumerable<Tuple<int, int>> FindSequences
             (IEnumerable<int> input)
        {
            // Use null values at the start and end of the ordered sequence
            // so that the first pair always starts a new sequence starting
            // with the lowest actual element, and the final pair always
            // starts a new one starting with null. That "sequence at the end"
            // is used to compute the length of the *real* final element.
            return End.Concat(input.OrderBy(x => x)
                                   .Select(x => (int?) x))
                      .Concat(End)
                      // Work out consecutive pairs of items
                      .SelectConsecutive((x, y) => Tuple.Create(x, y))
                      // Remove duplicates
                      .Where(z => z.Item1 != z.Item2)
                      // Keep the index so we can tell sequence length
                      .Select((z, index) => new { z, index })
                      // Find sequence starting points
                      .Where(both => both.z.Item2 != both.z.Item1 + 1)
                      .SelectConsecutive((start1, start2) => 
                           Tuple.Create(start2.index - start1.index, 
                                        start1.z.Item2.Value));
        }
    }
