    TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"); // Use "America/Chicago" on non-Windows systems
    
	Console.WriteLine("Id:             " + tzi.Id);
	Console.WriteLine("DisplayName:    " + tzi.DisplayName);
	Console.WriteLine("StandardName:   " + tzi.StandardName);
	Console.WriteLine("DaylightName:   " + tzi.DaylightName);
	Console.WriteLine();
	DateTime winterDate = new DateTime(2020, 1, 1);
	DateTime summerDate = new DateTime(2020, 7, 1);
	TimeSpan winterOffset = tzi.GetUtcOffset(winterDate);
	TimeSpan summerOffset = tzi.GetUtcOffset(summerDate);
	bool winterIsDst = tzi.IsDaylightSavingTime(winterDate);
	bool summerIsDst = tzi.IsDaylightSavingTime(summerDate);
	Console.WriteLine("Winter Offset:  " + winterOffset + "  IsDST:  " + winterIsDst);
	Console.WriteLine("Summer Offset:  " + summerOffset + "  IsDST:  " + summerIsDst);
