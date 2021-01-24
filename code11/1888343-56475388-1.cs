     var p = new DynamicParameters();
     p.Add("@inputInvoiceNumber", $"INV{DateTime.Now.Year}-{DateTime.Now.Month}-{result}, DbType.String, ParameterDirection.Input);
     p.Add("@retVal", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue); // If there is any return
    
     cnn.Execute("spTestProc", p, commandType: CommandType.StoredProcedure);
