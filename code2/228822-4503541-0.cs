    foreach(DataRow row in dt.Rows)
    {
       string separator = String.Empty;
       foreach(var cell in row.ItemArray)
       {
          builder.Append(separator);
          builder.Append(cell.ToString());
          separator  = "\t";
       }
       builder.Append(Environment.NewLine);
    }
