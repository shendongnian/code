    ...
    // note the change to Any()
    else if (!Rows.Any(row => row.HasColumn(colName))
    {
        throw new ArgumentException("No such column " + colName, "colName");
    }
    List<RowData> rowList = (from item in Rows
                             where item.HasColumn(colName)
                                && item[colName].Value == value
                             select item).ToList();
