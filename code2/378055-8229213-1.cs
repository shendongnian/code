    public static int GetId(this Context db, Type type, string name)
    {
    	var set = db.Set(type);
    	foreach (dynamic entry in set)
            if (entry.Name == name)
                return entry.Id; 
    }
