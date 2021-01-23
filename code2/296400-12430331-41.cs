    public static class EnumHelper
    {
      public static string Description(this Enum eValue)
      {
        var nAttributes = eValue.GetType().GetField(eValue.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
        // If no description is found, the least we can do is replace underscores with spaces
        if (!nAttributes.Any())
        {
          TextInfo oTI = CultureInfo.CurrentCulture.TextInfo;
          return oTI.ToTitleCase(oTI.ToLower(eValue.ToString().Replace("_", " ")));
        }
        return (nAttributes.First() as DescriptionAttribute).Description;
      }
      public static IEnumerable<ValueDescription> GetAllValuesAndDescriptions<T>() where T: struct, IConvertible, IComparable, IFormattable
      {
        if (!typeof(T).IsEnum)
          throw new ArgumentException("T must be an enum type");
        return Enum.GetValues(typeof(T)).Cast<Enum>().Select((e) => new ValueDescription() { Value = e, Description = e.Description() }).ToList();
      }
    }
