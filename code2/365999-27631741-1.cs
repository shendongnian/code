    DateTime dt;
    TimeZoneInfo tzf;
    tzf = TimeZoneInfo.FindSystemTimeZoneById("TimeZone String");
    dt = TimeZoneInfo.ConvertTime(DateTime.Now, tzf);
    lbltime.Text = dt.ToString();
