    namespace Extensions
    {
        using System;
        using System.Linq;
        using System.Collections.Generic;
    
        public static class IEnumerableExtensions
        {
            public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> collection, bool condition, Func<T, bool> predicate)
            {
                return condition ? collection.Where(predicate) : collection;
            }
        }
    }
