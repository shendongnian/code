    if (row is IDictionary<string, object>)
    {
    	var rowDictionary = row as IDictionary<string, object>;
    	if (rowDictionary.ContainsKey(""))
    	{
    		var kvs = rowDictionary.ToList();
    		rowDictionary.Clear();
    
    		for (var i = 0; i < kvs.Count; ++i)
    		{
    			var kv = kvs[i];
    			
    			var key = kv.Key == ""? $"(No Column <{i + 1}>)" : kv.Key;
    			rowDictionary.Add(key, kv.Value);
    		}
    	}
    }
