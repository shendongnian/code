	// Your original input
	var dto1 = DateTimeOffset.Parse("2019-11-13T22:00:00.0000000+02:00");
	// Here's one way to get the value you asked for:
	var dto2 = new DateTimeOffset(dto1.DateTime, TimeSpan.Zero);
	// Here's another way, which does the same thing:
	var dto3 = dto1.Add(dto1.Offset).ToUniversalTime();
	// But note that dto2 and dto3 are a different point in time.
    // The actual UTC point in time is given by:
	var dto4 = dto1.ToUniversalTime();
	Console.WriteLine(dto1.ToString("o")); // "2019-11-13T22:00:00.0000000+02:00"
	Console.WriteLine(dto2.ToString("o")); // "2019-11-13T22:00:00.0000000+00:00"
	Console.WriteLine(dto3.ToString("o")); // "2019-11-13T22:00:00.0000000+00:00"
	Console.WriteLine(dto4.ToString("o")); // "2019-11-13T20:00:00.0000000+00:00"
