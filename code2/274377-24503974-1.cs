    Regex rgx = new Regex("[ +-]");
    foreach (var timeZone in TimeZoneInfo.GetSystemTimeZones())
    {
        Console.WriteLine("  <data name=\"{0}\" xml:space=\"preserve\">", rgx.Replace(timeZone.Id, string.Empty));
        Console.WriteLine("    <value>{0}</value>", timeZone.DisplayName);
        Console.WriteLine("  </data>");
    }
