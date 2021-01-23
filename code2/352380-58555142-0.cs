    public static IEnumerable<double> Range(double min, double max, double step)
    {
        double result = min;
        for (int i = 0; result<max; i++)
        {
            result = min + (step * i);
            yield return result;
        }
    }
