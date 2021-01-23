    public static string GetNewData(DataRow row)
    {
      string res = string.Empty;
      if (row == null) throw new ArgumentNullException("row");
    
      foreach (DataColumn column in dg2.Columns)
        if (row.IsNull(column.ColumnName) || string.IsNullOrEmpty(row[column.ColumnName].ToString()))
          return string.Empty;
        else
          res += row[column.ColumnName] + " ";
    
      return res.Trim();
    }
