    public static IEnumerable<T> MergeWithRatio<T>(this IEnumerable<T> source, IEnumerable<T> mergeSequence, int ratio)
    {
        using (IEnumerator<T> sourceEnumerator = source.GetEnumerator(), 
                              mergeSequenceEnumerator = mergeSequence.GetEnumerator())
        {
            int i = 1;
            while (sourceEnumerator.MoveNext())
            {
                yield return sourceEnumerator.Current;
                i++;
                if (i == ratio)
                {
                    if (!mergeSequenceEnumerator.MoveNext())
                    {
                        mergeSequenceEnumerator.Reset();
                        mergeSequenceEnumerator.MoveNext();
                    }
                    yield return mergeSequenceEnumerator.Current;
                    i = 1;
                }
            }
        }
    }
