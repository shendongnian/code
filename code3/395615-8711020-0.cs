    var dt1 = new DataTable(); // Replace with Dt1
    var dt2 = new DataTable(); // Replace with Dt2
    	
    var result = dt1.AsEnumerable()
    		    .Union(dt2.AsEnumerable())
    		    .OrderBy (d => d.Field<string>("emp_name"));
