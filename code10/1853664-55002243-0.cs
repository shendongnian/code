    public static string StripSpacesAndSpecialCharacters(this string text)
    {
       var specChars = new string[] { "'", ";" }; // add more spec chars here
                var procesesedString = text.Trim();
    
       foreach (var spec in specChars)
       {
         procesesedString = procesesedString.Replace(spec, string.Empty);
       }
       return procesesedString;
    }
