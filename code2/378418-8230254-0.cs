    for(int i=0;i < dt.Columns.Count; i++)
    {
      if (dt.Columns[i].ColumnName.StartsWith("Total Price"))
      {
        var curBracket = Convert.ToInt32(dt.Columns[i].ColumnName.SubString(11));
        AddProductPrice(SKU, curRow[dt.Columns[i].ColumnName, curBracket);
      }
    }
