    DataView dataView = new DataView(dataTable);
    dataView.RowFilter = String.Format("EventDate > '{0}'", DateTime.Now);
    dataView.Sort = "EventDate";
    dataTable = dataView.ToTable();
    while (dataTable.Rows.Count > _rowLimit)
    {
        dataTable = dataTable.AsEnumerable().Skip(0).Take(50).CopyToDataTable();
    }
    return dataTable;
