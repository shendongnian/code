    public static IEnumerable<double> Range(double min, double max, double step)
    {
        double result = min;
        int decPlaces = BitConverter.GetBytes(decimal.GetBits((decimal)step)[3])[2];
        for (int i = 0; result<max; i++)
        {
            result = min + (step * i);
            yield return Math.Round(result,decPlaces);
        }
    }
