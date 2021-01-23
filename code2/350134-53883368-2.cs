    private IEnumerable<(string groupName, string rowSpan)> GetRowGroups(string columnName)
    {
        return from table in _dataSetDataTable.AsEnumerable()
               group table by new { column1 = table[columnName] }
               into groupedTable
               select (groupedTable.Key.column1, groupedTable.Count());
    }
