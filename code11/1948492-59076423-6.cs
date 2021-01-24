    public bool IsValidDateFormat(string dateFormat)
    {
        try {
            string s = DateTime.Now.ToString(dateFormat, CultureInfo.InvariantCulture);
            DateTime.Parse(s, CultureInfo.InvariantCulture);
            return true;
        } catch {
            return false;
        }
    }
