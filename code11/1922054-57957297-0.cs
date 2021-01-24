    public System.Globalization.CultureInfo GetCurrentCultureInfo )
    {
        var androidLocale = Java.Util.Locale.Default;
        var netLanguage = androidLocale.ToString().Replace ("_", "-");
        if(netLanguage == "iw-IL" || netLanguage == "iw")
        {
            netLanguage = "he-IL";
            SetLocale();
        }
        return new System.Globalization.CultureInfo(netLanguage);
    }
