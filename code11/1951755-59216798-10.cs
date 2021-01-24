    public static DateTime GetDate(string input)
    {
        DateTime result;
        if (!DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.CurrentCulture,
            DateTimeStyles.None, out result))
        {
            throw new FormatException("date must be in the format: 'MM/dd/yyyy'");
        }
        return result;
    }
