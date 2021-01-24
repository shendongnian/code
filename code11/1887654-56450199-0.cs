    string sql = "SELECT TOP 10 * FROM ClientModels";
    using (var connection = new SqlConnection("your connection string"))
    {			
    	var clientModels = connection.Query<ClientModel>(sql).ToList();
        foreach(var clientModel in clientModels)
        {
            // do something with clientModel
            ...
        }
    }
