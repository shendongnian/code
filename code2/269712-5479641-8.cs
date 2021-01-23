    public static void ForEachSingleTerminated<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate,
        Action<TSource> action)
    {
        using (var enumerator = source.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate(item))
                {
                    action(item);
                }
                else
                {
                    // verify there are no more failing items
                    while (enumerator.MoveNext())
                    {
                        if (!predicate(enumerator.Current))
                            throw new InvalidOperationException("Sequence is not properly terminated");
                    }
                    action(item);
                    break;
                }
            }
        }
    }
