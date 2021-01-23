	if (e.ColumnIndex == 0) //change this to your column
	{
		String sqlFormat = "MM/dd/yyyy"; //change this to the sql format
		DateTime parsedDateTime = DateTime.ParseExact(e.Value, sqlFormat, null);
		TimeZoneInfo tziEastern = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
		e.Value = TimeZoneInfo.ConvertTimeToUtc(parseDateTime, tziEastern);
	}
