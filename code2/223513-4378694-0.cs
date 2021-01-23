    static DateTime? parse(string text)
    {
        Match m = Regex.Match(text, @"^(\w\w\w)(\d+)$");
        if (m.Success)
        {
            var month = Array.IndexOf(CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames, m.Groups[1].Value);
            return new DateTime(2000 + Convert.ToInt32(m.Groups[2].Value), month + 1, 1);
        }
        m = Regex.Match(text, @"^Q(\d+) (\d+)$");
        if (m.Success)
        {
            return new DateTime(2000 + Convert.ToInt32(m.Groups[2].Value), 3 * (Convert.ToInt32(m.Groups[1].Value) - 1) + 1, 1);
        }
        return null;
    }
