    private static DateTime getLastExecutionTime(string text, string nameFile)
    {
        string lastRun = Regex.Match(text, "(?:" + nameFile + ") ([0-9]{2}-[0-9]{2}-[0-9]{4} [0-9]{2}:[0-9]{2})").Groups[1].Value;
        if (string.IsNullOrEmpty(lastRun))
            return new DateTime();
        return DateTime.Parse(lastRun);
    }
