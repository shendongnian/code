    var ReturnData = new
    	{
            total = totalPages,
            page = page,
            records = totalRecords,
            rows = myCollection.Select(r => new
    		{
    			id = r.Id.ToString(),
    			cell = new String[] { r.Field1, r.Field2, r.Field3, r.Field4 }
    		})
            };
    	
    return (Json(ReturnData, JsonRequestBehavior.DenyGet));
