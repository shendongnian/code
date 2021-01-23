    static readonly DateTime oaEpoch = new DateTime(1899, 12, 30);
    public static DateTime FromOADatePrecise(double d)
    {
      if (!(d >= 0))
        throw new ArgumentOutOfRangeException(); // NaN or negative d not supported
      return oaEpoch + TimeSpan.FromTicks(Convert.ToInt64(d * TimeSpan.TicksPerDay)):
    }
    public static double ToOADatePrecise(this DateTime dt)
    {
      if (dt < oaEpoch)
        throw new ArgumentOutOfRangeException();
      return Convert.ToDouble((dt - oaEpoch).Ticks) / TimeSpan.TicksPerDay;
    }
