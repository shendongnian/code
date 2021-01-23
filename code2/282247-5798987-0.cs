    public static string ConvertDateTimeToDate(string dateTimeString, String langCulture) {
    
        CultureInfo culture = new CultureInfo(langCulture);
        DateTime dt = DateTime.MinValue;
    
        if (DateTime.TryParse(dateTimeString, out dt))
        {
            return dt.ToString("d",culture);
        }
        return dateTimeString;
      }
