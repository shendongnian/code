    DateTime result;
    if (DateTime.TryParseExact(dateString, dateFormat, culture, DateTimeStyles.None, out result))
    {
        return result;
    }
    else 
    {
        return new ValidationResult("Date string format error");
    }
