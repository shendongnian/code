    // Sample values, replace them with your code that builds the increments array
    string[] increments = new string[] {"VALUE1", "VALUE2","VALUE3", "VALUE4"};
    
    // Invariant part of your query
    string baseQuery = "INSERT INTO [Manufacturing].[dbo].[Device.Devices]([SerialNumber],[DeviceTypeID]) VALUES"; 
    // Fixed value for the type 
    string dType = "42";
    
    List<SqlParameter> prms = new List<SqlParameter>();
    List<string> placeHolders = new List<String>();
    // Build a list of parameter placeholders and a list of those parameter and their values
    for(int x = 0; x < increments.Length; x++)
    {
        placeHolders.Add($"(@p{x},{dType})");
        prms.Add(new SqlParameter { ParameterName = $"@p{x}", SqlDbType = SqlDbType.NVarChar, Value = increments[x]});
    }
    // Put the text together
    string queryText = baseQuery + string.Join(",", placeHolders);
    // This should be the final text
    // INSERT INTO [Manufacturing].[dbo].[Device.Devices]([SerialNumber],[DeviceTypeID])  
    // VALUES(@p0,42),(@p1,42),(@p2,42),(@p3,42)
    using (SqlCommand insertCommand = new SqlCommand(queryText, cnn))
    {
        // Add all parameters to the command...
        insertCommand.Parameters.AddRange(prms.ToArray());
        var executeNonQuery = insertCommand.ExecuteNonQuery();
    }
