    using (var db = new MyContext())
    {
    	var meanAssCat = context.MeanCats.Find(CurrentCat.Id)
    	var entityType = ObjectContext.GetObjectType(meanAssCat.GetType());
    }
