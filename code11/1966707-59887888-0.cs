	string dateRange = "Mon Oct 07 2019 00:00:00 GMT-0400 (Eastern Daylight Time)Sat Nov 23 2019 00:00:00 GMT-0500 (Eastern Standard Time)";
	
	string[] parts = dateRange.Split('(',')');
	
	string format = "ddd MMM dd yyyy HH:mm:ss 'GMT'zzz";
	
	DateTimeOffset start = DateTimeOffset.ParseExact(parts[0].Trim(), format, CultureInfo.InvariantCulture);
	DateTimeOffset end = DateTimeOffset.ParseExact(parts[2].Trim(), format, CultureInfo.InvariantCulture);
		
	Console.WriteLine(start.ToString("o"));  // 2019-10-07T00:00:00.0000000-04:00
	Console.WriteLine(end.ToString("o"));    // 2019-11-23T00:00:00.0000000-05:00
