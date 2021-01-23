    using (var iterator = images.Find(query).SetLimit(1).GetEnumerator())
    {
    	while (iterator.MoveNext())
    	{
    		var bsonDoc = iterator.Current;
    		// do something with bsonDoc
    	}
    }
