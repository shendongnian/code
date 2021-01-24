    public static DateTime NearestInterval(DateTime value, TimeSpan interval)
    {
        var temp = value.Add(new TimeSpan(interval.Ticks/2));
    	var time = new TimeSpan((temp.TimeOfDay.Ticks / interval.Ticks) * interval.Ticks);
    	
        return value.Date.Add(time);
    }
