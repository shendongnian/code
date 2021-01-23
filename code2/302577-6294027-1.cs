    public DataTable ConvertDataReader(SqlDataReader dr)
    {
      SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); 
      DataTable dtSchema = dr.GetSchemaTable();
      DataTable dt = new DataTable();
     
      // You can also use an ArrayList instead of List<>
      List<DataColumn> listCols = new List<DataColumn>();            
      if(dtSchema != null) 
      {
         foreach (DataRow drow in dtSchema.Rows)
         {
            string columnName = System.Convert.ToString(drow["ColumnName"]); 
            DataColumn column = new DataColumn(columnName, 
                                   (Type)(drow["DataType"]));
            column.Unique = (bool)drow["IsUnique"];
            column.AllowDBNull = (bool)drow["AllowDBNull"];
            column.AutoIncrement = (bool)drow["IsAutoIncrement"];
            listCols.Add(column);
            dt.Columns.Add(column);
         }
      }
     
      // Read rows from DataReader and populate the DataTable 
      while (dr.Read())
      {
        DataRow dataRow = dt.NewRow();
        for(int i = 0; i < listCols.Count; i++)
        {
          dataRow[((DataColumn)listCols[i])] = dr[i];
        }
        dt.Rows.Add(dataRow);
      }
    }
