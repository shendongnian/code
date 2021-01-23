    public static class Extensions
    {
      public static bool IsInRange(this int value, int min, int max)
      {
        return value >= min && value <= max;
      }
    }
