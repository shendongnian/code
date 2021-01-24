    // only required once per app-domain, unless SqlMapper.ResetTypeHandlers() is called
    SqlMapper.AddTypeHandler(typeof(Date), new DateHandler()); 
    DynamicParameters parameters = new DynamicParameters();
    parameters.Add("MyDate", new Date() { MyDate = DateTime.Today });
    
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        connection.Execute(
            sql: "dbo.InsertDate", 
            param: parameters, 
            commandType: CommandType.StoredProcedure);
    }
