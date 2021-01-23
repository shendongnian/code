    //wrap your context in a using so it gets disposed once you're done
    using (var dbm = new MyDataContext())
    {
    	var query = dbm.Categories.Select(c => new 
    			    { 
    				    Category = c, 
    				    //get all of the related subcategories
    				    Subcategories = dbm.SubCategories.Where(s => s.CategoryID == c.CategoryID) 
    			    });
    	
    	resultSpan.InnerHtml += "<table>";
    	
    	foreach (var result in query)
    	{
    		resultSpan.InnerHtml += "<tr><td>" + result.Category.Name + "</td></tr>";
    		//now go through the subcategories for this category
    		foreach (var sub in result.Subcategories)
    		{
    			resultSpan.InnerHtml += "<tr><td>&nbsp;&nbsp;&nbsp;" + sub.SubCategoryName + "</td></td>";
    		}	
    	}
    	
    	resultSpan.InnerHtml += "</table>";
    }
