      using System.Globalization;
      using System.Linq;
      ...
      public static partial class StringExtensions {
        public static String ConvertNumerals(this string source, 
                                             CultureInfo culture = null) {
          if (null == source)
            return null;
    
          if (null == culture)
            culture = CultureInfo.CurrentCulture;
    
          string[] digits = culture.NumberFormat.NativeDigits.Length >= 10 
            ? culture.NumberFormat.NativeDigits
            : CultureInfo.InvariantCulture.NumberFormat.NativeDigits;
          return string.Concat(source
            .Select(c => char.IsDigit(c)
               ? digits[(int) (char.GetNumericValue(c) + 0.5)]
               : c.ToString()));
        }
      } 
