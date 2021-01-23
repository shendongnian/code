      ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["SomeConnectionName"];
      if (connectionStringSettings == null)
        throw new Exception("Application config file does not contain a connectionStrings section with a connection called \"SomeConnectionName\"");
      DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory(connectionStringSettings.ProviderName);
      using (var dbConnection = dbProviderFactory.CreateConnection())
      {
        dbConnection.ConnectionString = connectionStringSettings.ConnectionString;
        dbConnection.Open();
        using (var command = dbConnection.CreateCommand())
        {
          command.CommandText = "INSERT INTO Login([Username],[Password]) VALUES(@Username, @Password)";
          
          var parameter = dbProviderFactory.CreateParameter();
          parameter.DbType = System.Data.DbType.String;
          parameter.ParameterName = "@Username";
          parameter.Value = AddUsernameTextBox.Text;
          command.Parameters.Add(parameter);
    
          parameter = dbProviderFactory.CreateParameter();
          parameter.DbType = System.Data.DbType.String;
          parameter.ParameterName = "@Password";
          parameter.Value = AddPasswordTextBox.Text;
          command.Parameters.Add(parameter);
    
          var dbTransaction = dbConnection.BeginTransaction();
          try
          {
            command.ExecuteNonQuery();
            dbTransaction.Commit();
          }
          catch (Exception)
          {
            dbTransaction.Rollback();
            throw;
          }
        }
      }
