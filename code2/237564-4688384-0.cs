    string getDataQuery =
            "SELECT customer,custtrack,ackdate FROM famain WHERE faid = @lcFaid";
    SqlDataAdapter masterDataAdapter = new SqlDataAdapter();
    masterDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
    masterDataAdapter.SelectCommand = new SqlCommand();
    masterDataAdapter.SelectCommand .Connection = sqlConnection1;
    // first set the query text
    masterDataAdapter.SelectCommand.CommandText = getDataQuery;
    // after that, define the parametesr
    masterDataAdapter.SelectCommand.Parameters
      .Add("@lcFaid", SqlDbType.UniqueIdentifier, 36, "faid").SourceVersion = DataRowVersion.Original;
