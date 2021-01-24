    public static IEnumerable<Interval> MergeOverlapping(this IEnumerable<Interval> source)
    {
        using (var enumerator = source.GetEnumerator())
        {
            if (!enumerator.MoveNext())
                yield break;
            var previousInterval = enumerator.Current;
            while (enumerator.MoveNext())
            {
                var nextInterval = enumerator.Current;
                if (!previousInterval.Overlaps(nextInterval))
                {
                    yield return previousInterval;
                    previousInterval = nextInterval;
                }
                else
                {
                    previousInterval = previousInterval.MergeWith(nextInterval);
                }
            }
            yield return previousInterval;
        }
    }
