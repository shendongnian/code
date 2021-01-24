	public static string getProcedureEndingDateTime (string input) {
		
		// example input: "05/06/2019|1330|60"
		
		// separate the offset from the rest of the string
		string dateTimeString = input.Substring(0, 15);
		string offsetString = input.Substring(16);
		
		// parse the DateTime as given, and parse the offset separately, inverting the sign
		DateTime dt = DateTime.ParseExact(dateTimeString, "MM/dd/yyyy|HHmm", CultureInfo.InvariantCulture);
		TimeSpan offset = TimeSpan.FromMinutes(-int.Parse(offsetString));
		
		// create a DateTimeOffset from these two components
		DateTimeOffset dto = new DateTimeOffset(dt, offset);
		
		// Convert to UTC and return a string in the desired format
		DateTime utcDateTime = dto.UtcDateTime;
		return utcDateTime.ToString("MM/dd/yyyy'T'HH:mm:ss", CultureInfo.InvariantCulture);
	}
