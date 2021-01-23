    public double Round(double input, int decimalPlaces)
    {
      double precision = 2.0 * Math.Pow(10, decimalPlaces - 1);
      // Ceiling also rounds negative values in positive direction
      return Math.Ceiling(x * precision) / precision;
    }
