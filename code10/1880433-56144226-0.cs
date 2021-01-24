    using (var csv = new CsvReader(reader))
    {
    	dynObj = csv.GetRecords<dynamic>().ToList();
    
    	foreach (var d in dynObj)
    	{
    		var obj = d as System.Dynamic.ExpandoObject;
    
    		if (obj != null)
    		{
    			var keys = obj.Select(a => a.Key).ToList();
    			var values = obj.Select(a => a.Value).ToList();
    		}
    	}
    }
