    static double SampleStandardDeviation_ForEach (
        this IEnumerable<int> ints)
    {
        var length = ints.Count ();
        if (length < 2)
        {
            return 0.0;
        }
        const double seed = 0.0;
        var average = ints.Average ();
        var state = seed;
        foreach (var value in ints)
        {
            state = SumOfQuadraticDistance (average, value, state);
        }
        var sumOfQuadraticDistance = state;
        return Math.Sqrt (sumOfQuadraticDistance / (length - 1));
    }
