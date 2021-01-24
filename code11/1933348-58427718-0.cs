    TimeSpan[] hours = new[] { 
			new TimeSpan(10,35,50), 
			new TimeSpan(10,36,48), 
			new TimeSpan(10,41,48), 
			new TimeSpan(10,47,58), 
			new TimeSpan(10,49,14), 
			new TimeSpan(11,22,15), 
			new TimeSpan(11,24,18), 
			new TimeSpan(11,25,25), 
		};
		var query = hours.Aggregate(new List<(int group, TimeSpan ts)>(),  (acc,curr) => {
			if(acc.Count == 0)
				acc.Add((0,curr));			
			else 
			{
				var (lastGroup,lastTs) = acc.Last();
				if(curr.Subtract(lastTs).TotalMinutes <= 5)
					acc.Add((lastGroup,curr));
				else
					acc.Add((lastGroup+1,curr));
			}
			return acc;
		}).GroupBy(x => x.group, y => y.ts);
		foreach(var item in query)
			Console.WriteLine(String.Join(", ", item));
