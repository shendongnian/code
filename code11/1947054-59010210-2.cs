    public static Statistics GetStatistics<T>(IEnumerable<T> list, Func<T, double> getValue)
    {
        var stats = new Statistics();
        var valuesToCalculate = list.Select(getValue);
        stats.Sum = valuesToCalculate.Sum();
        stats.Median = valuesToCalculate.Median();
        // ... More calculations
        return stats;
    }
