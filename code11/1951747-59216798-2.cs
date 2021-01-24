    public static bool IsWithinDays(string date, int days)
    {
        DateTime input;
        if (!DateTime.TryParseExact(date, "MM/dd/yyyy", CultureInfo.CurrentCulture, 
            DateTimeStyles.None,  out input))
        {
            throw new ArgumentException("date must be in the format 'MM/dd/yyyy'");
        }
        return DateTime.Today.Subtract(input).TotalDays <= days;
    }
