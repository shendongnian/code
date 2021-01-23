    public static string Pluralize(this string @string)
    {
         if (string.IsNullOrEmpty(@string)) return string.Empty;
         var service = new EnglishPluralizationService();
         return service.Pluralize(@string);
    }
