    public static IEnumerable<Tuple<T, T>> Tupelize<T>(this IEnumerable<T> source)
            {
                using (var enumerator = source.GetEnumerator())
                    while (enumerator.MoveNext())
                    {
                        var item1 = enumerator.Current;
    
                        if (!enumerator.MoveNext())
                            throw new ArgumentException();
    
                        var item2 = enumerator.Current;
    
                        yield return new Tuple<T, T>(item1, item2);
                    }
            }
