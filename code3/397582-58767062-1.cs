    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class Extensions
    {
        public static IEnumerable<TResult> Sandwich<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource, TResult> projection) where TSource : class
        {
            var withExtras = source.AddFakeSlices();
    
            var prevCurrNext = withExtras
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
    
            foreach (var item in prevCurrNext)
            {
                yield return projection(item.Previous, item.Current, item.Next);
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
