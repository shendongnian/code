    public static DateTime NearestQuarter(DateTime value)
    {
    	var temp = value.AddMinutes(7).AddSeconds(30);
    	return new DateTime(temp.Year, temp.Month, temp.Day, temp.Hour, (temp.Minute / 15) * 15, 0);
    }
