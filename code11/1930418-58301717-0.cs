      public static partial class StringExtensions {
        private static String ConvertNumerals(public string source, 
                                              CultureInfo culture = null) {
          if (null == source)
            return null;
    
          if (null == culture)
            culture = CultureInfo.CurrentCulture;
    
          char zero = ci.NumberFormat.NativeDigits.Length <= 0
            ? '0'
            : culture.NumberFormat.NativeDigits[0][0];
    
          return string.Concat(source
            .Select(c => char.IsDigit(c)
               ? (char)(zero + char.GetNumericValue(c) + 0.5)
               : c));
        }
      } 
