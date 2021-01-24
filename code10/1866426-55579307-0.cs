    private static string GetRegex(string propRegex)
    {
        string restrictedChars = ConfigureationManager.AppSettings.Get("RestrChar");
        string[] thisCharArray = restrictedChars.Split(',');
        return Regex.Replace(propRegex, 
            $"[{string.Concat(thisCharArray)}]+", "");
    }
