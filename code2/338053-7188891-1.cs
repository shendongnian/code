    public static IEnumerable<TOutput> SelectIgnoringExceptions<TInput, TOutput>(this IEnumerable<TInput> values, Func<TInput, TOutput> selector)
       {
            foreach (var item in values)
            {
                TOutput output = default(TOutput);
                try
                {
                    output = selector(item);
                }
                catch 
                {
                    continue;
                }
                yield return output;
            }
        }
