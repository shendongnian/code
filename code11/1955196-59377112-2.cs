    var days = new List<Translation>();
    var languages = Enum.GetValues(typeof(Language)).Cast<Language>();
    var cultures = languages.Select(x => x).ToDictionary(
                       k => k, 
                       v => new CultureInfo(v.ToString()).DateTimeFormat);
    foreach (var dayOfWeek in Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>())
    {
        days.Add(new Translation()
        {
            Key = cultures[Language.EN].GetAbbreviatedDayName(dayOfWeek),
            Values = languages.ToDictionary(k => k, v => cultures[v].GetDayName(dayOfWeek))
        });
    }
