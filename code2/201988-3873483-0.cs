    string value = "09/20/2010 14:30";
    DateTime CompletedDttm = DateTime.ParseExact(value, "MM/dd/yyyy HH:mm", 
        CultureInfo.CurrentCulture);
    CompletedDttm = TimeZoneInfo.ConvertTime(CompletedDttm, TimeZoneInfo.Local,
        TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"));
    string output = CompletedDttm.ToString(new CultureInfo("en-GB"));
