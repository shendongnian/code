        // Method GetExcelData opens 1 excel file, reads data row by row and adds
        // it into the array of source Data Values (sourceDataValues in our case).
        private void GetExcelData(string fullPath, ArrayList arrForValues)
        {
            
            Microsoft.Office.Interop.Excel.Application excelapp = new Microsoft.Office.Interop.Excel.Application();
            excelapp.Visible = false;
            // to avoid appearing of Excel window on the screen
            Microsoft.Office.Interop.Excel.Workbook excelappworkbook = excelapp.Workbooks.Open(
                fullPath,
                Type.Missing, Type.Missing, true, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet excelworksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelappworkbook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range excelcells = excelworksheet.UsedRange;
            Microsoft.Office.Interop.Excel.Range newRange = excelworksheet.get_Range("A1","A"+excelcells.Rows.Count);
            object[,] items = newRange.Value;
            for (int i = 1; i < items.Length; i++)
            {
                arrForValues.Add(items[i,1]);
            }
            excelappworkbook.Close(false, Type.Missing, Type.Missing);
            excelapp.Quit();
        }
