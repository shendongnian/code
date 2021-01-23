    public var LoadDatabaseRecords(int timezoneOffset)
    {
        MyDatabaseDataContext dc = new MyDatabaseDataContext();
    
        List<MyDatabaseRecords> ListOfRecords = dc.MyDatabaseRecords.ToList();
    
        var results = (from OneRecord in ListOfRecords
    		   select new
    		   {
    		       ID = OneRecord.Log_ID,
    		       Message = OneRecord.Log_Message,
    		       StartTime =  FromUTCData(OneRecord.Log_Start_Time, timezoneOffset),
    		       EndTime = FromUTCData(OneRecord.Log_End_Time, timezoneOffset)
    		   }).ToList();
    
        return results;
    }
    
    public static DateTime? FromUTCData(DateTime? dt, int timezoneOffset)
    {
        if (dt == null)
    	    return null;
    
        DateTime newDate = dt.Value - new TimeSpan(timezoneOffset / 60, timezoneOffset % 60, 0);
        return newDate;
    }
