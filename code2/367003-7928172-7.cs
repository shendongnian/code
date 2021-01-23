			var dates = Enumerable.Range(1, daysInMonth)
							.Select(n => new DateTime(today.Year, today.Month, n))
							.Where(date => date.DayOfWeek != DayOfWeek.Sunday)
							.SkipWhile(date => date.DayOfWeek != DayOfWeek.Monday)
							.Reverse()
							.SkipWhile(date => date.DayOfWeek != DayOfWeek.Saturday)
							.Reverse()
							.ToArray();
