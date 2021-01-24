    private static DateTime getLastExecutionTime(string text, string nameFile)
    {
        string lastRun = string.Empty;
        if (Regex.IsMatch(text, nameFile))
        {
            lastRun = Regex.Match(text.Substring(text.IndexOf(nameFile)), " [0-9]{2}-[0-9]{2}-[0-9]{4} [0-9]{2}:[0-9]{2}").ToString();
            return DateTime.Parse(lastRun);
        }
        return new DateTime();
    }
