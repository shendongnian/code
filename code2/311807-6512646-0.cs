    public static string CheckInsertRecord(String eventType, String beginDate, String endDate)
    {
    	NCDCPoint ncdc = new NCDCPoint();
    	CEOSurveyDataContext CDC = new CEOSurveyDataContext();
    	int et = Convert.ToInt32(eventType);
    	CultureInfo provider = CultureInfo.InvariantCulture;
    
    	String queryBeingDate = string.Empty;
    	String queryEndDate = string.Empty;
    	DateTime beginDateTime;
    	DateTime endDateTime;
    	if (DateTime.TryParse(beginDate, out beginDateTime))
    	{
    	   queryBeingDate = beginDateTime.ToString("yyyy-MM-dd");
    	}
    
    	if(DateTime.TryParse(endDate, out endDateTime))
    	{
    	   queryEndDate = endDate;
    	}
    
    	var query = (from n in CDC.NCDCPoints
    				 where n.EVENT_TYPE_ID == et && n.BeginDate == b && n.EndDate == e
    				 select new
    				 {
    					 n.EVENT_TYPE_ID,
    					 BeginDate = queryBeingDate,
    					 EndDate = queryEndDate,
    					 n.BeginLATLONG,
    					 n.EndLATLONG
    				 });
    }
    
