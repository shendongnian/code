    public double FromUnixEpoch(DateTime value)
    {
    	DateTime unixEpoch = new DateTime(1970, 1, 1);
    	double timeStamp = (value - unixEpoch).Ticks / 1000;
    	return timeStamp;
    }
	
