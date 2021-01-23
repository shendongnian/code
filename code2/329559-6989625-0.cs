    using (var ctx = new DataContext())
    {
    	ctx.Users.Attach(existingUser);
    
    	// create item and add to context
    	var newItem = new MyItem();
    	ctx.MyItems.Add(newItem);
    
    	// set related entity
    	newItem.CreatedBy = existingUser;
    	
    	// Added
    	ctx.ObjectStateManager.ChangeObjectState(newItem.CreatedBy, EntityState.Added);
    
    	ctx.SaveChanges();
    }
