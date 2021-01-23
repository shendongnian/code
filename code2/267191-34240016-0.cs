    static void ReadExcelFile(filename) {
       Excel.Application xlApp = new Excel.Application();
       Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(filename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
       Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); // 1st sheet
       // the entire table :
       Excel.Range range = xlWorkSheet.UsedRange; // range.Rows.Count, range.Columns.Count
           
       for (int col = 1; col <= range.Columns.Count; col++) {
            // this line does only one COM interop call for the whole column
            object[,] currentColumn = (object[,])range.Columns[col, Type.Missing].Value; 
            double sum = 0;
            for (int i = 1; i < currentColumn.Length; i++) {
                 object val = currentColumn[i, 1];
                 sum += (double)val; // only if you know that the values are numbers 
                 // if it was a string column :
                 //Console.WriteLine("{0}",(string)val);
            }
        }
    }
