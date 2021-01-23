	var start= new DateTime(2009,01,01).Ticks;
		var end= new DateTime(2009,01,10).Ticks;
		List<DateTime> dates = new List<DateTime>();
		for (var i = start; i < end; i+=TimeSpan.TicksPerDay) {
			dates.Add(new DateTime(i));
	}
    
