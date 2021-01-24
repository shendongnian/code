    DataTable dt = new DataTable();
    
    using(var dataAdapter = new MySqlDataAdapter("SELECT SUM(decimals) FROM myTable", connectionString)) {
    	dataAdapter.Fill(dt); //fills the datatable
    	double myDoubleSum = 0.0; // stores the sum
    	
    	allDoubles = Convert.ToDouble(row[0].ToString()); 
    }
