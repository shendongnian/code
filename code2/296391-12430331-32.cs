    public static class EnumHelper
    {
      /// <summary>
      /// Gets the description of a specific enum value.
      /// </summary>
      public static string Description(this Enum eValue)
      {
        var nAttributes = eValue.GetType().GetField(eValue.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
        // If no description is found, best guess is to generate it by replacing underscores with spaces
        if (!nAttributes.Any())
         return  CultureInfo.CurrentCulture.TextInfo.ToTitleCase(oTI.ToLower(eValue.ToString().Replace("_", " ")));
        return (nAttributes.First() as DescriptionAttribute).Description;
      }
      /// <summary>
      /// Returns an enumerable collection of all values and descriptions for an enum type.
      /// </summary>
      public static IEnumerable<ValueDescription> GetAllValuesAndDescriptions<TEnum>() where TEnum: struct, IConvertible, IComparable, IFormattable
      {
        if (!typeof(TEnum).IsEnum)
          throw new ArgumentException("TEnum must be an Enumeration type");
        return Enum.GetValues(typeof(TEnum)).Cast<Enum>().Select((e) => new ValueDescription() { Value = e, Description = e.Description() }).ToList();
      }
    }
