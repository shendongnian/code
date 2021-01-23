    public static IEnumerable<T> MergeWithRatio<T>(this IEnumerable<T> source, IEnumerable<T> mergeSequence, int ratio)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
        if (mergeSequence == null)
        {
            throw new ArgumentNullException("mergeSequence");
        }
        if (ratio <= 1)
        {
            throw new ArgumentOutOfRangeException("ratio must be greater one.");
        }
        return MergeWithRatioImpl(source, mergeSequence, ratio);
    }
    private static IEnumerable<T> MergeWithRatioImpl<T>(this IEnumerable<T> source, IEnumerable<T> mergeSequence, int ratio)
    {
        bool mergeSequenceContainsElements = true;
        int i = 1;
        ratio--;
        using (var sourceEnumerator = source.GetEnumerator())
        using (var mergeSequenceEnumerator = mergeSequence.GetEnumerator())
        {
            while (sourceEnumerator.MoveNext())
            {
                yield return sourceEnumerator.Current;
                if (i++ % ratio == 0)
                {
                    if (!mergeSequenceEnumerator.MoveNext())
                    {
                        // ToDo: Should we cache the current values for the case the
                        //       enumerator can't be reset?
                        mergeSequenceEnumerator.Reset();
                        mergeSequenceContainsElements = mergeSequenceEnumerator.MoveNext();
                    }
                    if (mergeSequenceContainsElements)
                    {
                        yield return mergeSequenceEnumerator.Current;
                    }
                }
            }
        }
    }
