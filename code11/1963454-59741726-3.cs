    public Response<List<Colleges>> GetCollegeList()
    {
    	List<Colleges> collegelist = new List<Colleges>();
    		
    	dt =obj.GetCollegeList();
    
    	if (dt.Rows.Count > 0)
    	{
    		foreach (DataRow row in dt.Rows)
    		{
    			collegelist.Add(
    			   new Colleges
    			   {
    				   CollegeId = Convert.ToInt32(row["CollegeId"].ToString()),
    				   CollegeName = row["CollegeName"].ToString() 
    			   }
    			 );
    		}
    	}
    	Response<List<Colleges>> response = Response<List<Colleges>>()
    	{
    		status_code = "success", 
    		responsemessage = "College List", 
    		data = collegelist 
    	};
    
    
    	return response;
    }
