    public static IEnumerable<double> Range(double min, double max, double step)
    {
        double i;
        for (i=min; i<=max; i+=step)
            yield return i;
        if (i != max+step) // added only because you want max to be returned as last item
            yield return max; 
    }
