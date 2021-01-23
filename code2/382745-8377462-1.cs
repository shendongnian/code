    public static class IntExtensions
    {
        public static bool In(this int @this, params int[] values)
        {
          return values.Contains(@this);
        }
    }
