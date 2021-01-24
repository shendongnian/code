    public static class HelperExtenxsions
    {
      public static bool HasMultipleFlags<TEnum>(TEnum enumValue) where TEnum : IConvertible 
      {
        return Math.Log(enumValue.ToInt32(CultureInfo.InvariantCulture.NumberFormat), 2) % 1 == 0;
      }
    }
