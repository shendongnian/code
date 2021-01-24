    private static double Middle(double test, double? bottom, double? top) =>
      Middle(
        test, 
        bottom ?? Double.NegativeInfinity, 
        top ?? Double.PositiveInfinity);
    private static double Middle(double test, double bottom, double top) =>
      Math.Min(Math.Max(test, bottom), top);
