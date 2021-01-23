			DateTime today = DateTime.Now;
			DateTime lastWorkingDay;
			if (today.DayOfWeek == DayOfWeek.Monday) 
			{
				lastWorkingDay = today.AddDays(-3);
			}
			else
			{
				lastWorkingDay = today.AddDays(-1);
			}
			Console.WriteLine(lastWorkingDay);
