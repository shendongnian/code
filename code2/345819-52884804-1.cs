        Excel.Application xlApp ;
        Excel.Workbook xlWorkBook ;
        Excel.Worksheet xlWorkSheet ;
        object misValue = System.Reflection.Missing.Value;
        xlApp = new Excel.ApplicationClass();
        xlWorkBook = xlApp.Workbooks.Add(misValue);
        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        int i = 0;
        int j = 0;
        /*header text*/
        for (i = 0; i <= dgvInventory.Columns.Count - 1; i++)
        {
          xlWorkSheet.Cells[1, i+1] = dgvView.Columns[i].HeaderText; 
        }
        /*And the information of your data*/
        for (i = 0; i <= dgvInventory.RowCount - 1; i++)
        {
            for (j = 0; j <= dgvInventory.ColumnCount - 1; j++)
            {
                DataGridViewCell cell = dgvInventory[j, i];
                xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
            }
        }
        xlWorkBook.SaveAs(
            "D:\\exp.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue,misValue, misValue, misValue, misValue);
        xlWorkBook.Close(true, misValue, misValue);
        xlApp.Quit();
        releaseObject(xlWorkSheet);
        releaseObject(xlWorkBook);
        releaseObject(xlApp);
