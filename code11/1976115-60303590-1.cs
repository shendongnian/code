    var employees = new List<Employee>();
    while (dr.read())
    {
    	employees.Add(new Employee
    		{
    			fname = dr["name],
    			Departments = dr["Department"].ToString() // I don't think you need ToString here.
    						   .Split(new[] {"--"}, StringSplitOptions.RemoveEmptyEntries).ToList()
       
    	});
    }
