    // ten digits 
    public string CreateRandomNumber
    {
    	get
    	{
    		//returns 10 digit random number (Ticks returns 16 digit unique number, substring it to 10)
    		return DateTime.UtcNow.Ticks.ToString().Substring(8); 
    	}
    }
