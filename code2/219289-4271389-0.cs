    public static IEnumerable<T> WalkRanges<T>(IEnumerable<T> source, List<Tuple<int, int>> ranges)
    {
        if (ranges == null)
            return source;
        Debug.Assert(ranges.Count > 0);
        return WalkRangesInternal(source, ranges);
    }
    public static IEnumerable<T> WalkRangesInternal<T>(IEnumerable<T> source, List<Tuple<int, int>> ranges)
    {
        var rangeEnum = ranges.GetEnumerator();
        rangeEnum.MoveNext();
        int currentItem = 0;
        var sourceEnum = source.GetEnumerator();
        bool eol = false;
        // skip over items preceding first range
        while (currentItem < rangeEnum.Current.Item1
           && (eol = sourceEnum.MoveNext()))
            currentItem++;
        while (!eol)
        {
            // yield all the elements in the range
            while (currentItem <= rangeEnum.Current.Item2
               && (eol = sourceEnum.MoveNext()))
            {
                yield return sourceEnum.Current;
                currentItem++;
            }
            // advance to the next range
            if (!rangeEnum.MoveNext() || eol)
                yield break;
            // skip over every item in the gap between ranges
            while (currentItem < rangeEnum.Current.Item1
               && (eol = sourceEnum.MoveNext()))
                currentItem++;
        }
    }
