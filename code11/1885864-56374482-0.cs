    private static bool TryFormatTime(string time, out string formattedTime)
    {
        formattedTime = null;
        DateTime parsedDate;
        if (!DateTime.TryParseExact(time, "HHmm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
        {
            return false;
        }
        formattedTime = parsedDate.ToString("HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        return true;
    }
