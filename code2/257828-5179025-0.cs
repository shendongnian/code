    #region GetPostsFeatured
    
    internal DbDataReader GetPostsFeatured()
    {
      using (var command = CreateCommandForGetPostsFeatured())
      {
        DbConnection.Open();
        return command.ExecuteReader(CommandBehavior.CloseConnection);
      }
    }
    
    internal DataSet GetPostsFeaturedDataSet()
    {
      var adapter = DbProviderFactory.CreateDataAdapter();
      adapter.SelectCommand = CreateCommandForGetPostsFeatured();
      var ds = new DataSet();
      adapter.Fill(ds);
      return ds;
    }
    
    private DbCommand CreateCommandForGetPostsFeatured()
    {
      var command = DbConnection.CreateCommand();
      command.CommandType = CommandType.StoredProcedure;
      command.CommandText = "GetPostsFeatured";
      var parameter = DbProviderFactory.CreateParameter();
      parameter.DbType = DbType.Int32;
      parameter.Direction = ParameterDirection.ReturnValue;
      parameter.ParameterName = "@RETURN";
      command.Parameters.Add(parameter);
      return command;
    }
    
    #endregion GetPostsFeatured
