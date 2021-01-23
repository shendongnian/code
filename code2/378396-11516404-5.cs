        if (<<A predecessor exists>>){
    	Dependency[] dep = new Dependency[2];
    	dep[0] = new Dependency();
    	try{
    		/*
    		// Unique Identifier for your row based on what you are 
    		// passing to the GridSerializer while initializing it 
    		// (as a third parameter which is called keyColumnName)
    		// In my case I had to get it by doing some coding as  
    		// shown. The first object in the array represents the 
    		// previous row and so the unique identifier should  
    		// point to the previous row
    		*/
    		dep[0].Key = (
    				data.Select(
    					"ID=" + 
    					data.Rows[s]["PredecessorsID"].ToString()
    					)
    					[0]["Key"]
    				);
        }catch (Exception ex){ 
    		dep[0].Key = DBNull.Value; 
    	}
        dep[0].Type = LinkType.FinishStart;
    
    	/*
    	// Unique Identifier for your row based on what you are 
    	// passing to the GridSerializer while initializing it 
    	// (as a third parameter which is called keyColumnName)
    	// In my case I had to get it by doing some coding as  
    	// shown. The second object in the array represents the 
    	// current row and so the unique identifier should  
    	// point to the current row
    	*/
        dep[1] = new Dependency();
        try{ 
    		dep[1].Key = data.Rows[s]["Key"]; 
    	}catch (Exception ex){ 
    		dep[0].Key = DBNull.Value; 
    	}
        dep[1].Type = LinkType.StartFinish;
        data.Rows[s]["Predecessors"] = dep;
    }
