    public List<string> GetPrimaryKeysForTable(string tableName)
    {
        List<string> retVal = new List<string>();
        SqlCommand command = connector.GetCommand("sp_pkeys");
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@table_name", tableName);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            retVal.Add(reader[3].ToString());
        }
        return retVal;
    }
