    foreach (var culture in CultureInfo.GetCultures(CultureTypes.AllCultures))
    {
        if (culture.DateTimeFormat.MonthNames.Contains("ago") ||
            culture.DateTimeFormat.AbbreviatedMonthNames.Contains("ago"))
        {
           if (culture.DateTimeFormat.MonthNames.Contains("Aug") ||
               culture.DateTimeFormat.AbbreviatedMonthNames.Contains("Aug"))
           {
               Console.WriteLine(culture.Name);
           }
        }
    }
