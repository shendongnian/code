    var customers = new List<Customer>();
    string sql = "SELECT * FROM customers";
    using (var cnn = new SqlConnection("Data Source=Your_Server_Name;Initial Catalog=Your_Database_Name;Integrated Security=SSPI;")) {
    	cnn.Open();
    	using (var cmd = new SqlCommand(sql, cnn)) {
    		using (SqlDataReader reader = cmd.ExecuteReader()) {
    			// Get ordinals from the customers table
    			int custIdOrdinal = reader.GetOrdinal("CustomerID");
    			int nameOrdinal = reader.GetOrdinal("Name");
    			int imageOrdinal = reader.GetOrdinal("Image");
    			while (reader.Read()) {
    				var customer = new Customer();
    				customer.CustomerID = reader.GetInt32(custIdOrdinal);
    				customer.Name = reader.IsDBNull(nameOrdinal) ? null : reader.GetString(nameOrdinal);
    				if (!reader.IsDBNull(imageOrdinal)) {
    					var bytes = reader.GetSqlBytes(imageOrdinal);
    					customer.Image = bytes.Buffer;
    				}
    				customers.Add(customer);
    			}
    		}
    	}
    }
