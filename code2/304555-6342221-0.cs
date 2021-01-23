    private String DataRowToString(DataRow row, DataColumnCollection columns)
    {
       StringBuilder rowStringBuilder = New StringBuilder();
       foreach (DataColumn dc in columns)
       {
          dataRowBuilder.AppendFormat("{0} = {1}", dc.ColumnName, row(dc.Ordinal));
          dataRowBuilder.AppendLine();
       }
    
       return dataRowBuilder.ToString();
    }
    
    String rowString = ConvertDataRowToString(ds.Tables[0].Rows[0], ds.Tables[0].Columns)
