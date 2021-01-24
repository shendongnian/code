    public bool IsValidDateFormat(string dateFormat)
    {
        try {
            DateTime.ParseExact("12/31/2019", dateFormat, CultureInfo.InvariantCulture);
            return true;
        } catch {
            return false;
        }
    }
