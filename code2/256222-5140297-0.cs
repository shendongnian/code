      public static class DecimalExtensions
      {
        public static string ToString(this decimal? data, string formatString, string nullResult = "0.00")
        {
          return data.HasValue ? data.Value.ToString(formatString) : nullResult;
        }
      }
