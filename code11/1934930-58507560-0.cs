     public static IEnumerable<IEnumerable<int>> GetPythagoreanNumbers(IEnumerable<int> array)
            {
                ThrowNullException(array);
    
                return array.SelectSkip((a, inner) =>
                    inner.SelectSkip((b, result) =>
                        result.SelectMany(c => GetTriplePermutations(a, b, c))));
            }
     private static IEnumerable<T> SelectSkip<T>(
                this IEnumerable<int> source,
                Func<int, IEnumerable<int>, IEnumerable<T>> func)
            {
                return source.SelectMany((a, i) =>
                {
                    var inner = source.Skip(i + 1);
                    return func(a, inner);
                });
            }
