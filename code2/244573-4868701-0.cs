    protected void SetFormValue(string key, string value)
    {
    	var collection = HttpContext.Current.Request.Form;
    
    	// Get the "IsReadOnly" protected instance property. 
    	var propInfo = collection.GetType().GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
    
    	// Mark the collection as NOT "IsReadOnly" 
    	propInfo.SetValue(collection, false, new object[] { });
    
    	// Change the value of the key. 
    	collection[key] = value;
    
    	// Mark the collection back as "IsReadOnly" 
    	propInfo.SetValue(collection, true, new object[] { });
    } 
