	TimeSpan ScheduledTimespan;
	TimeSpan TimeOftheDay = TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString("hh\\:mm"));
	string[] formats = { @"hh\:mm\:ss", "hh\\:mm" };
	string strTime = Startup.Configuration["AppSettings:JobStartTime"].ToString();
	var success = TimeSpan.TryParseExact(strTime, formats, CultureInfo.InvariantCulture, out ScheduledTimespan);
	TimeSpan delayTime = ScheduledTimespan >= TimeOftheDay
		? ScheduledTimespan - TimeOftheDay    // When Scheduled Time for that day is not passed
		: new TimeSpan(24, 0, 0) - TimeOftheDay + ScheduledTimespan; // Passed - then Run Next day
	_timer = new Timer(ExecuteCompleteAbsentJob, null, delayTime, new TimeSpan(24, 0, 0));
