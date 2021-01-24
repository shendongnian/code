    DataTable dt = new DataTable();
    
    using(var dataAdapter = new MySqlDataAdapter("SELECT decimals FROM myTable", myConnectionString)) {
    	dataAdapter.Fill(dt); //fills the datatable
    	double allDoubles = 0.0; // stores the sum
    	
    	foreach(DataRow row in dt.Rows) {
    		allDoubles += Convert.ToDouble(row[0].ToString()); //adds to the double sum
    	}
    }
