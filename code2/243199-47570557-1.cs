    bool IsDateset = (Request.Form["TARGET_DATE"] != null) && Request.Form["TARGET_DATE"] != "";
    TargetDate = IsDateset ? Request.Form["TARGET_DATE"] : null;
	List<DateTime> TargetDatesAsDateTime = null;
    if (IsDateset)
    {
        List<DateTime> TargetDatesAsDateTime = new SelectList((from n in _db.ACTION_PLANs select n).ToList(), "TARGET_DATE", "TARGET_DATE", TargetDate);
    
        predicate = predicate.And(p => p.TARGET_DATE == Convert.ToDateTime(TargetDate)); // I'm unsure as to the purpose of this line of code. I left it in in case the surrounding code requires it.
        
    }
    else
    {
        List<DateTime> TargetDatesAsDateTime = new SelectList((from n in _db.ACTION_PLANs select n).ToList(), "TARGET_DATE", "TARGET_DATE");
        
    }
    
	List<string> TargetDateAsString = new List<string>();
	    
    if(TargetDatesAsDateTime != null || TargetDatesAsDateTime.Count > 0)
    {   	    
	    foreach(DateTime d in TargetDatesAsDateTime)
	    {
	        //string s = d.ToString("yyyy/MM/dd"); // Japan variant
	        //string s = d.ToString("dd/MM/yyyy"); // England variant
	        string s = d.ToString("MM/dd/yyyy"); // American variant
	    
	        TargetDateAsString.Add(s);
	        
	    }
	    
    }
    
	ViewData["TARGET_DATE"] = TargetDatesAsString;
	
