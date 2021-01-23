    public double Round(double input, int decimalPlaces)
    {
      double precision = 2.0 * decimalPlaces;
      if (input > 0)
      {
        return Math.Ceiling(x * precision) / precision;
      }
      else
      {
        // also round degative values in positive direction
        return Math.Floor(x * precision) / precision;
      }
    }
