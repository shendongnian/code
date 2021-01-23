    public static int GetId(this Context db, Type type, string name)
    {
    	int id = 0;
    	var set = db.Set(type);
    	foreach (dynamic entry in set)
    	{
    		if (entry.Name == name) id = entry.Id; 
    	}
    	return id;
    }
