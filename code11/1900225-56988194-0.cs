    public static IEnumerable<int> DistributeInteger(double total, int divider)
    {
        int part = 100 * ((int)(50 + total / divider) / 100);
        if (part == 0)
        {
            yield return (int)total;
            yield break;
        }
        double runningTotal = 0;
        while (runningTotal <= (total - part))
        {
            yield return part;
            runningTotal += part;
        }
        if (runningTotal < total)
            yield return (int) (total - runningTotal);
    }
