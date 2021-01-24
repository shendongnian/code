    public static void Reload(this CollectionEntry source)
    {
    	if (source.CurrentValue != null)
    	{
    		foreach (var item in source.CurrentValue)
    			source.EntityEntry.Context.Entry(item).State = EntityState.Detached;
    		source.CurrentValue = null;
    	}
    	source.IsLoaded = false;
    	source.Load();
    }
