    OracleDataAdapter adapter = new OracleDataAdapter(yourSQLQuery,yourConnString);
    DataSet data = new DataSet();
    
    adapter.Fill(data);
    
    if (data.Tables.Count != 0)
    {
        if (data.Tables[0].Rows.Count == 1)
        {
            ...
        }
    }
