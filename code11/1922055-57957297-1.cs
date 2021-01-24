    public System.Globalization.CultureInfo GetCurrentCultureInfo )
    {
        var androidLocale = Java.Util.Locale.Default;
        var netLanguage = androidLocale.ToString().Replace ("_", "-");
        return new System.Globalization.CultureInfo(netLanguage);
    }
