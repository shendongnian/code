    public DateTime? JavaScriptDateParse(string dateString)
    {
        DateTime date;
        return DateTime.TryParseExact(dateString, DATE_FORMAT, CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ? date : null;
    }
