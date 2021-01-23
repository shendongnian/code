    public static class StringHelper
    {     
       public static string ToTitleCase(this string text)
       {
          return StringHelper.ToTitleCase(text, CultureInfo.InvariantCulture);     
       }         
       public static string ToTitleCase(this string text, CultureInfo cultureInfo)
       {         
          if (string.IsNullOrEmpty(text)) return string.Empty;             
          TextInfo textInfo = cultureInfo.TextInfo;         
          return textInfo.ToTitleCase(text.ToLower());     
       } 
    }
