    public async Task GetGizmosSvcAsync()
    {
    	var client = new RestClient("https://api-developer.com/products");
    	client.Timeout = -1;
    	var request = new RestRequest(Method.POST);
    	request.AddHeader("Content-Type", "application/json");
    	request.AddHeader("Accept", "application/json");
    	request.AddParameter("application/json", "{\"category\": \"all\"}", ParameterType.RequestBody);
    
    	var response2 = await client.ExecuteTaskAsync<RootObject>(request);
    	var products = response2.Data;  //List products = response2.Data; 
    
    	//INSERT DATA INTO DB SQL SERVER
    	string connectionString = "Data Source=utente-pc\\SQLEXPRESS;Initial Catalog=MYDB;Persist Security Info=True;User ID=user;Password=sa";
    	SqlConnection connection = new SqlConnection(connectionString);
    
    	try
    	{
    
    		SqlCommand cmd = new SqlCommand("INSERT INTO PRODUCT (code, name, description) VALUES (@code, @name, @description)", connection);
    		connection.Open();
    
    		foreach (var product in products)
    		{
    			cmd.Parameters.AddWithValue("@code", product.code);
    			cmd.Parameters.AddWithValue("@name", product.name);
    			cmd.Parameters.AddWithValue("@description", product.description);
    			cmd.ExecuteNonQuery();
    		}
    	}
    
    	catch
    	{
    		//Label4.Text = "uh oh";
    	}
    }
