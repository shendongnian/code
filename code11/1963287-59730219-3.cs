	TimeSpan ScheduledTimespan;
	TimeSpan TimeOftheDay = TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString("hh\\:mm"));
	string[] formats = { @"hh\:mm\:ss", "hh\\:mm" };
	string strTime = Startup.Configuration["AppSettings:JobStartTime"].ToString();
	var success = TimeSpan.TryParseExact(strTime, formats, CultureInfo.InvariantCulture, out ScheduledTimespan);
