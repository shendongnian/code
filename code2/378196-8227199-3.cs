    foreach(var r in oldList)
    {
    	Table t = new Table();
    	t.Id        = r.Id ;
  	
      	Table.Attach(t);
    	t.FK_ID   = new Guid(...some new guid here...));
    }
    SubmitChanges();
