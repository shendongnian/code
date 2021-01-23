			DateTime now = DateTime.Now;
			for (int i = 0; i < 7; ++i)
			{
				DateTime d = new DateTime(now.Year, now.Month, i+1);
				if (d.DayOfWeek == DayOfWeek.Friday)
				{
					return d.AddDays(14);
				}
			}
