    Datatable dtExcel = importaExcelaDT(filePath);
        
    for(int i = 0; i < dtExcel.Columns.Count; i++)
    {
        string columnName = dtExcel.Rows[0][i].ToString();
        if (columnName == "") //throws error if column name is empty
            columnName = " ";
        dtExcel.Columns[i].ColumnName = columnName;
    }
    dtExcel.Rows.RemoveAt(0);
        
    yourDataGridView.DataSource = dtExcel;
