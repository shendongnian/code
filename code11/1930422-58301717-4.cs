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
    
          string[] digits = ci.NumberFormat.NativeDigits.Length >= 10 
            ? ci.NumberFormat.NativeDigits
            : new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
          return string.Concat(source
            .Select(c => char.IsDigit(c)
               ? digits[(int) (char.GetNumericValue(c) + 0.5)]
               : c.ToString()));
        }
      } 
