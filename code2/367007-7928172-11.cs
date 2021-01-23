			DateTime today = DateTime.Today;
			int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);
			List<DateTime> dates = new List<DateTime>();
			bool foundFirst = false;
			for (int n = 1; n <= daysInMonth; n++)
			{
				var date = new DateTime(today.Year, today.Month, n);
				// Skip untill we find the first Monday of the month.
				if (date.DayOfWeek != DayOfWeek.Monday && !foundFirst)
					continue;
				foundFirst = true;
				// Add all days except Sundays. 
				if (date.DayOfWeek != DayOfWeek.Sunday)
					dates.Add(date);
				int remainingDays = daysInMonth - n;
				// Verify that there are enough days left in this month to add all days upto the next Saturday.
				if (date.DayOfWeek == DayOfWeek.Saturday && remainingDays < 7)
					break;
			}
			DateTime[] dateArray = dates.ToArray();
