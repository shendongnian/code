       public void Export(DataSet ds, string filePath)
        {
            string data = null;
            string columnName = null;
            int i = 0;
            int j = 0;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            //Excel.Worksheet xlWorkSheet;
            Excel.Worksheet xlWorkSheet = null;
            object misValue = System.Reflection.Missing.Value;
            Excel.Range range;
            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            for (int l = 0; l < ds.Tables.Count; l++)
            {
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(l + 1);                
                xlWorkSheet.get_Range("A1:D1", Type.Missing).Merge(Type.Missing);
                xlWorkSheet.get_Range("A1", "D1").Font.Bold = true;
                xlWorkSheet.Cells.Font.Name = "Courier New";
                
                for (i = 0; i <= ds.Tables[l].Rows.Count - 1; i++)
                {
                    
                    for (j = 0; j <= ds.Tables[l].Columns.Count - 1; j++)
                    {
                        columnName = ds.Tables[l].Columns[j].ColumnName.ToString();
                        xlWorkSheet.Cells[3, j + 1] = columnName;
                        data = ds.Tables[l].Rows[i].ItemArray[j].ToString();
                        xlWorkSheet.Cells[i + 5, j + 1] = data;
                    }
                }
            }
            xlWorkBook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            // kill all excel processes
            Process[] pros = Process.GetProcesses();
            for (int p = 0; p < pros.Length; p++)
            {
                if (pros[p].ProcessName.ToLower().Contains("excel"))
                {
                    pros[p].Kill();
                    break;
                }
            }
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
