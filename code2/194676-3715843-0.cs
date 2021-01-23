        private void ProcessExcel(string filepath)
        {
                Excel.ApplicationClass ExcelObj = new Excel.ApplicationClass();
                Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(filepath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Excel.Sheets sheets = theWorkbook.Worksheets;
                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);
                Excel.Range range = worksheet.UsedRange;
                System.Array myvalues = (System.Array)range.Cells.Value2;
                /* do your stuff */
        }
