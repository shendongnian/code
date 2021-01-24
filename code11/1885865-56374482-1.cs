    private static bool TryFormatTime(string time, out string formattedTime)
    {
        formattedTime = null;
        if (time.Length != 4 || !time.All(c => char.IsDigit(c)))
        {
            return false;
        }
        formattedTime = string.Format("{0}:{1}", time.Substring(0, 2), time.Substring(2, 2));
        return true;
    }
