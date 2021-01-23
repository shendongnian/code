    private List<dynamic> GetRowGroups(string columnName)
    {
    var groupQuery = from table in _dataSetDataTable.AsEnumerable()
                                 group table by new { column1 = table[columnName] }
                                     into groupedTable
                                     select new
                                     {
                                         groupName = groupedTable.Key.column1,
                                         rowSpan = groupedTable.Count()
                                     };
        return groupQuery.ToList<dynamic>();
    }
