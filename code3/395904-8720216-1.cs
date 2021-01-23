    private static TimeSpan getTimespan(string time1)
    {
    	Regex reg = new Regex(@"\d+");
    	MatchCollection matches = reg.Matches(time1);
    	if (matches.Count == 2)
    	{
    		int minutes = int.Parse(matches[0].Value);
    		int seconds = int.Parse(matches[1].Value);
    		return new TimeSpan(0, minutes, seconds);
    	}
    	return TimeSpan.Zero;
    }
