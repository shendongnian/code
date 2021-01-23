    public static string ProperCase(string stringToFormat)
    {
        CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
        TextInfo textInfo = cultureInfo.TextInfo;
    
        // Check if we have a string to format
        if (String.IsNullOrEmpty(stringToFormat))
        {
            // Return an empty string
            return string.Empty;
        }
    
        // Format the string to Proper Case
        return textInfo.ToTitleCase(stringToFormat.ToLower());
    }   
