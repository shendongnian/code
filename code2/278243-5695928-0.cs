    public static class LinqExt 
        {
            public static decimal? MySum<TSource>(this IEnumerable<TSource> list, Func<TSource,decimal?> selector)
            {
                decimal? result = 0;
                foreach (var p in list) 
                {
                    result += selector(p);
                }
                return result;
            }
        }
