    private static bool Overlap(Range a, Range b)
    {
        if (a.Start >= b.Start && a.Start <= b.End)
        {
            return true;
        }
        if (b.Start >= a.Start && b.Start <= a.End)
        {
            return true;
        }
        return false;
    }
    private static bool CheckOverlap(List<Range> ranges)
    {
        for (var i = 0; i < ranges.Count - 1; i++)
        {
            for (var j = i + 1; j < ranges.Count; j++)
            {
                if (Overlap(ranges[i], ranges[j]))
                {
                    return false;
                }
            }
        }
        return true;
    }
