    public static DataTable SchemaReader(string tableName) 
    {      
      string sql = "MySP";//replace this with your store procedure name      
      conn.Open();      
      SqlCommand cmd = new SqlCommand(sql, conn);
      cmd.CommandType = CommandType.StoredProcedure;      
      SqlDataReader reader = cmd.ExecuteReader();       
      DataTable schema = reader.GetSchemaTable();       
      reader.Close();      
      conn.Close();      
      return schema; 
    }
