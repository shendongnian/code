    var gList = _DBcontext.AppProcessCrashEvents
    		.Where(x => x.Actee == item.AppGuid)
    		.OrderByDescending(p => p.UpdatedAt)
    		.ToList();
    
    var result = new Events
    {
    	Actee = gList[0].Actee,
    	UpdatedAt = gList[0].UpdatedAt,
    	CrashCount = gList[0].CrashCount - gList[gList.Count - 1].CrashCount
    };
