    class DateTimeWrapper 
    {
    	private DateTime _date;
    	
    	public DateTime Date 
    	{
    		get { return _date; }
    		set { _date = new DateTime(value.Ticks, DateTimeKind.Utc);}
    	}
    }
