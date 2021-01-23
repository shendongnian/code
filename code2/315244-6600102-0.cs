    DateTime date = DateTime.Today;
    
    // Make the kind "unspecified" to ensure the conversion is performed
    // appropriately.
    DateTime localDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0,
                                      DateTimeKind.Unspecified);
    DateTime utcStart = TimeZoneInfo.ConvertTimeToUtc(localDate, timeZone);
    DateTime utcEnd = TimeZoneInfo.ConvertTimeToUtc(localDate.AddDays(1),
                                                    timeZone);
