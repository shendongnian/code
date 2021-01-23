    private DateTime ParseDate(string date)
    {
        DateTime convertedDate;
    
        if (!DateTime.TryParseExact(date, "ddMMyyyy", new CultureInfo("en-US"),
             DateTimeStyles.None, out convertedDate))
    
            throw new FormatException(string.Format("Unable to format date:{0}", date));
        
        return convertedDate;
    
    }
