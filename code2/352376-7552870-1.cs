    public static IEnumerable<double> Range(double min, double max, double step)
    {
        for (double i=min; i<=max; i+=step)
            yield return i;
    }
