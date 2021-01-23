    public static IEnumerable<string> ToRanges(this IEnumerable<int> values)
    {
        int? start = null, end = null;
        foreach (var value in values.OrderBy(vv => vv))
        {
            if (!start.HasValue)
            {
                start = value;
            }
            else if (value == (end ?? start) + 1)
            {
                end = value;
            }
            else
            {
                yield return end.HasValue
                    ? String.Format("{0}-{1}", start, end)
                    : String.Format("{0}", start);
                start = value;
                end = null;
            }
        }
        if (start.HasValue)
        {
            yield return end.HasValue
                ? String.Format("{0}-{1}", start, end)
                : String.Format("{0}", start);
        }
    }
