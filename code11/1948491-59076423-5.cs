    public bool IsValidDateFormat(string dateFormat)
    {
        try {
            DateTime.Now.ToString(dateFormat, CultureInfo.InvariantCulture);
            return true;
        } catch {
            return false;
        }
    }
