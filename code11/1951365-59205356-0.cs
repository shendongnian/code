    if (firstCronDate.Value.Date == currentDateTimeWithPaddingDays.Date)
	{
		if (!validDates.Contains(currentDateTimeWithPaddingDays.Date))
		{
			validDates.Add(currentDateTimeWithPaddingDays.ToUniversalTime().Date);
		}
	}
