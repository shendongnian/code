    	DateTime[] dates = new  DateTime[] { 
           DateTime.Parse("06-07-2019 10:00AM"),
           DateTime.Parse("06-07-2019 11:00AM"),
           DateTime.Parse("05-07-2019 10:00 pm")
        };
		
		foreach(var d in dates.OrderBy(x => x.Date).ThenBy(x => x.TimeOfDay))
		{
			Console.WriteLine(d.ToString("dd MMM yyyy hh:mm"));
		}
