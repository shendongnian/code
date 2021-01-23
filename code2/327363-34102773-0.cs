    public static string formatDateTimeWithTimeIfNotMidnight(DateTime dt)
    {
    	//RETURN:
    	//		= String for 'dt' that will have time only if it's not midnight
    
    	if (dt != dt.Date)
    	{
    		//Use time
    		return dt.ToString();
    	}
    	else
    	{
    		//Only date
    		return dt.ToShortDateString();
    	}
    }
