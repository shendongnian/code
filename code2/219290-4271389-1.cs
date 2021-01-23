    public static IEnumerable<T> WalkRanges<T>(IEnumerable<T> source, List<Tuple<int, int>> ranges)
    {
        if (ranges == null)
            return source;
        Debug.Assert(ranges.Count > 0);
        return WalkRangesInternal(source, ranges);
    }
    static IEnumerable<T> WalkRangesInternal<T>(IEnumerable<T> source, List<Tuple<int, int>> ranges)
    {
        int currentItem = 0;
        var rangeEnum = ranges.GetEnumerator();
        bool moreData = rangeEnum.MoveNext();
        using (var sourceEnum = source.GetEnumerator())
            while (moreData)
            {
                // skip over every item in the gap between ranges
                while (currentItem < rangeEnum.Current.Item1
                   && (moreData = sourceEnum.MoveNext()))
                    currentItem++;
                // yield all the elements in the range
                while (currentItem <= rangeEnum.Current.Item2
                   && (moreData = sourceEnum.MoveNext()))
                {
                    yield return sourceEnum.Current;
                    currentItem++;
                }
                // advance to the next range
                moreData = rangeEnum.MoveNext();
            }
    }
