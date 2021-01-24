    using (var context = new EntityContext())
    {
    	// could be set globally in the constructor
    	var materialized = new List<object>();
    	((IObjectContextAdapter) context).ObjectContext.ObjectMaterialized += (sender, args) => materialized.Add(args.Entity);
    	
    	var list = context.Customers.ToList();
    	
    	FiddleHelper.WriteTable(materialized);		
    }
