    public static double StdDev<T>(this IEnumerable<T> values, Func<T, double?> selector)
    {
        double ret = 0;
        var count = values.Count();
        if (count > 0)
        {
            // Compute the Average
            double? avg = values.Average(selector);
            // Perform the Sum of (value-avg)^2
            double sum = values.Select(selector).Sum(d =>
            {
                if (d.HasValue)
                {
                    return Math.Pow(d.Value - avg.Value, 2);
                }
                return 0.0;
            });
            // Put it all together
            ret = Math.Sqrt((sum) / (count - 1));
        }
        return ret;
    }
