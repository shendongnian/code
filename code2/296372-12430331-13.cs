    public static class EnumHelper
    {
      public static string Description(this Enum eValue)
      {
        var nAttributes = eValue.GetType().GetField(eValue.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (!nAttributes.Any())
          return eValue.ToString();
        return (nAttributes.First() as DescriptionAttribute).Description;
      }
    }
