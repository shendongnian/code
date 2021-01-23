    public ActionResult All(string sidx, string sord, int page, int rows)
    {
    	int totalRecords = _repository.Count();
    
        // first sorting the data as IQueryable<Ticket> without converting ToList()
    	IQueryable<Ticket> orderdData = ZTRepository.GetAllTickets();
    	System.Reflection.PropertyInfo propertyInfo =
    		typeof(Ticket).GetProperty (sortIndex);
    	if (propertyInfo != null) {
    		orderdData = String.Compare(sord,"desc",StringComparison.Ordinal) == 0 ?
    			(from x in _repository
    			 orderby propertyInfo.GetValue (x, null) descending
    			 select x) :
    			(from x in _repository
    			 orderby propertyInfo.GetValue (x, null)
    			 select x);
    	}
    	
    	// paging of the results
    	IQueryable<Ticket> pagedData = orderdData
    		.Skip ((page > 0? page - 1: 0) * rows)
    		.Take (rows);
    
    	var rowdata = ( from ticket in tickets
    					select new {
    						id = ticket.ID,
    						cell = new String[] {
    							ticket.ID.ToString(), ticket.Hardware, ticket.Issue,
    							ticket.IssueDetails, ticket.RequestedBy,
    							ticket.AssignedTo, ticket.Priority.ToString(),
    							ticket.State
    						}
    					}).ToList();				
    
    	var jsonData = new {
    		total = page,
    		Records = totalRecords,
    		total = (totalRecords + rows - 1) / rows,
    		rows = pagedData
    	};
    		
    	return Json(jsonData, JsonRequestBehavior.AllowGet);
    }
