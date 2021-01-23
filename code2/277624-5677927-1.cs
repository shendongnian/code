    public void AddReferenceToCollection(object targetResource, string propertyName, object resourceToBeAdded)
    {
    	var col = targetResource.GetType().GetProperty(propertyName).GetValue(targetResource, null) as IList;
    	if(col != null)
    		col.Add(resourceToBeAdded);
    	else
    		throw new InvalidOperationException("Not a list");
    }
