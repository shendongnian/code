    public void ExportToExcel(DataTable currentTable)
    {
        DataTable tblFiltered = currentTable.AsEnumerable()
                              .Where(r => r.Field<string>("Type") == ExportGridGroup)
                              .CopyToDataTable();
        // ... 
    }
