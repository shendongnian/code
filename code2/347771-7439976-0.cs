    var newRow = dataTable.NewRow();
    
    ...
    ...
    
    if(YourText.Length < ColumnMaxLength)
    {
      newRow["YourLimitedColumnName"] = YourText;
    }
    else
    {
      newRow["YourLimitedColumnName"] = YourText.Substring(0, ColumnMaxLength);
    }
    
    ...
    ...
    
    dataTable.Rows.Add(newRow);
