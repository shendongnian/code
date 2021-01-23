    public static class ValidatedDateTimeOperations
    {
      public static bool TrySubtract (this DateTime dateTime, TimeSpan span, out DateTime result)
      {
        if (span < TimeSpan.Zero)
           return TryAdd (dateTime, -span, out result);
        if (dateTime.Ticks >= span.Ticks)
        {
           result = dateTime - span;
           return true;
        }
        result = DateTime.MinValue;
        return false;
      }
      public static bool TryAdd (this DateTime dateTime, TimeSpan span, out DateTime result)
      {
        if (span < TimeSpan.Zero)
           return TrySubtract (dateTime, -span, out result);
        if (DateTime.MaxValue.Ticks - span.Ticks >= dateTime.Ticks)
        {
           result = dateTime + span;
           return true;
        }
        result = DateTime.MaxValue;
        return false;
      }
    }
