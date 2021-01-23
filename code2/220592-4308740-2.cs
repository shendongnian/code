    using (var dbm = new MyDataContext())
    {
    	var query = dbm.Categories
    				join s in dbm.SubCategories on c.CategoryID equals s.CategoryID
    				//group the related subcategories into a collection
    				into subCollection
    				select new { Category = c, SubCategories = subCollection };
    	  	
    	foreach (var result in query)
    	{
		    //use result.Category here...
    		//now go through the subcategories for this category
    		foreach (var sub in result.Subcategories)
    		{
    		    //use sub here...
    		}	
    	}
    }
