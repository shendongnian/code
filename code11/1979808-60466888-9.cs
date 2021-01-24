    public static class HelperExtenxsions
    {
      public static bool HasMultipleFlags<TEnum>(this TEnum enumValue) where TEnum : Enum, IConvertible 
      {
        return Math.Log(enumValue.ToInt32(CultureInfo.InvariantCulture.NumberFormat), 2) % 1 != 0;
      }
    }
