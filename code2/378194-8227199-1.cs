    foreach(var r in oldList)
    {
    	Table t = new Table();
    	t.Id        = r.Id ;
    	t.s.FK_ID   = new Guid(...some new guid here...));
  	
      	Table.Attach(t);
    }
    SubmitChanges();
