    var SSOId = " get from webapi";
    
    if (!string.IsNullOrEmpty(SSOId))
    {
    	Entity entityToUpdate = new Entity("systemuser", new Guid(entity.Id));
    	entityToUpdate["new_ssoid"] = SSOId;
    	service.Update(entityToUpdate);
    }
    else
    {
    	throw new InvalidPluginExecutionException("userID not exist");
    }
