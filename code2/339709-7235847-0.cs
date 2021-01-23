    var results = (from rec in Record group rec by rec.CustID into grp 
    	select new
    	{
    		CustID = grp.Key,
    		ID = grp.OrderByDescending(r => r.ID).Select(x => x.ID).FirstOrDefault(),
    		Data = grp.OrderByDescending(r => r.ID).Select(x => x.Data).FirstOrDefault()
    	}
    );
