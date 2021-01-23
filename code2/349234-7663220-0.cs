    string filter = "";
    
    foreach (DataColumn dc in dt.Columns)
    {
        filter += dc.ColumnName + " <> '' ";
        if (dt.Columns[dt.Columns.Count-1].ColumnName != dc.ColumnName)
        {
            filter += " AND ";
        }
    }
    DataView view = new DataView(dt);
    view.RowFilter = filter;
    dt = view.ToTable();
