	var date = new DateTime(DateTime.Now.Year,1,1);
	if(date.DayOfWeek > DayOfWeek.Tuesday)
		date = date.AddDays(9 - (int)date.DayOfWeek);
	else if(date.DayOfWeek < DayOfWeek.Tuesday)
		date = date.AddDays(2 - (int)date.DayOfWeek);
	date = date.AddDays(7);
