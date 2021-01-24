    public static double CountOfWeekEnds(DateTime startDate, DateTime endDate)
	{          
		double weekEndCount = 0;
		if (startDate > endDate)
		{
			DateTime temp = startDate;
			startDate = endDate;
			endDate = temp;
		}
		
		TimeSpan diff = endDate.Date - startDate.Date; //instead of endDate - startDate
		int days = diff.Days; 
		
		for (var i = 0; i <= days; i++)
		{
			var testDate = startDate.AddDays(i);
			//Console.WriteLine(testDate);
			if (testDate.DayOfWeek == DayOfWeek.Saturday || testDate.DayOfWeek == DayOfWeek.Sunday) //only weekends count
			{
				if (testDate.Date < endDate.Date && startDate.Date != endDate.Date) { // added  startDate.Date != endDate.Date
					weekEndCount += 1440; // 24h * 60 min
					//Console.WriteLine("************************add 1440 ");
				}
				else
				{    
					double difference;
					difference = (endDate - testDate).TotalMinutes; //instead of endDate -  todayStart
					//Console.WriteLine("************************add " + difference);
					weekEndCount += difference;
				}                  
			}
		}
		//return days;
		return weekEndCount;
	}
