    theSqlConnection.Open();
    
    SqlDataReader reader = sqlCommand.ExecuteReader();
    DataTable schemaTable = reader.GetSchemaTable();
    
    foreach (DataRow row in schemaTable.Rows)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
    
        using (JsonWriter jsonWriter = new JsonTextWriter(sw)) 
        {    
            jsonWriter.WriteStartObject();
    
            foreach (DataColumn column in schemaTable.Columns)
            {
                jsonWriter.WritePropertyName(column.ColumnName);
                jsonWriter.WriteValue(row[column]);
            }
    
            jsonWriter.WriteEndObject();
        }
    }
    	
    theSqlConnection.Close();
