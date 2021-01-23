    static IEnumerable<Range> FindRanges(IEnumerable<int> source, int minCount)
    {
        // throw exceptions on invalid arguments, maybe...
        var ordered = source.OrderBy(x => x);
        Range r = default(Range);
        foreach (int value in ordered)
        {
            // In "real" code I would've overridden the Equals method
            // and overloaded the == operator to write something like
            // if (r == Range.Empty) here... but this works well enough
            // for now, since the only time r.Count will be 0 is on the
            // first item.
            if (r.Count == 0)
            {
                r = new Range(value, 1);
                continue;
            }
            if (value == r.End)
            {
                // skip duplicates
                continue;
            }
            else if (value == r.End + 1)
            {
                // "append" consecutive values to the range
                r += 1;
            }
            else
            {
                // return what we've got so far
                if (r.Count >= minCount)
                {
                    yield return r;
                }
                // start over
                r = new Range(value, 1);
            }
        }
        // return whatever we ended up with
        if (r.Count >= minCount)
        {
            yield return r;
        }
    }
