    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class Extensions
    {
        public static IEnumerable<Sandwich<TSource>> Sandwich<TSource>(this IList<TSource> source)
        {
            var withExtras = source.AddFakeSlices();
    
            var sandwiches = withExtras
                                    .Skip(1)
                                    .Zip(withExtras, (curr, prev) => new
                                    {
                                        Current = curr,
                                        Previous = prev
                                    })
                                    .Zip(withExtras.Skip(2), (curr, next) => new
                                    {
                                        curr.Previous,
                                        curr.Current,
                                        Next = next
                                    });
    
            foreach (var item in sandwiches)
            {
                var sandwich = new Sandwich<TSource>()
                {
                    Previous = item.Previous,
                    Current = item.Current,
                    Next = item.Next
                };
    
                yield return sandwich;
            }
        }
    
        private static IEnumerable<TResult> AddFakeSlices<TResult>(this IEnumerable<TResult> source)
        {
            yield return default;   //a fake item, so that the first 'Previous' value is null
    
            foreach (var item in source)
            {
                yield return item;
            }
    
            yield return default;   //a fake item, so that the last 'Next' value is null
        }
    }
    
    public class Sandwich<T>
    {
        public T Previous;
        public T Current;
        public T Next;
    }
