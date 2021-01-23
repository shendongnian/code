    static class StringExtension
    {
      public static string RemoveTrailingText(this string text, string textToRemove)
      {
        if (!text.EndsWith(textToRemove))
          return text;
    
        return text.Substring(0, text.Length - textToRemove.Length);
      }
    }
