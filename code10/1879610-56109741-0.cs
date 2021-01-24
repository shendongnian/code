    public DateTime? ToDateTime(string text)
    {
        DateTime? returnValue = null;
        System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-GB");
        DateTime d = new DateTime();
        if(DateTime.TryParse(text, cultureInfo, System.Globalization.DateTimeStyles.None, out d))
        {
            returnValue = d;
        }
        return returnValue;
    }
