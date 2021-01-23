    private void RefreshSheets(string filePath)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbooks xlWorkbooks = xlApp.Workbooks;
            Excel.Workbook xlWorkbook = xlWorkbooks.Open(filePath);
            foreach (Excel.Worksheet xlworksheet in xlWorkbook.Worksheets)
            {
                Excel.PivotTables pivotTbls = (Excel.PivotTables)xlworksheet.PivotTables(Type.Missing);
                if (pivotTbls.Count > 0)
                {
                    for (int i = 1; i <= pivotTbls.Count; j++)
                    {
                        pivotTbls.Item(i).RefreshTable();
                    }
                }
            }
            xlWorkbook.Save();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            xlWorkbook.Close(0);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(xlWorkbooks);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }
