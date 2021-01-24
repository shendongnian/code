    public static class HelperExtenxsions
    {
      public static bool HasMultipleFlags(this IConvertible enumValue) 
      {
        return Math.Log(enumValue.ToInt32(CultureInfo.InvariantCulture.NumberFormat), 2) % 1 != 0;
      }
    }
