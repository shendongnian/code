    private List<string> GetKeywordsList(string xlsFilePath)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;
            string str;
            int rCnt = 0;
            int cCnt = 0;
            List<string> keywords = new List<string>();
            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Open(xlsFilePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
            {
                for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                {
                    if (!(((range.Cells[rCnt, cCnt] as Excel.Range).Value2) == null))
                    {
                        if ((range.Cells[rCnt, cCnt] as Excel.Range).Value2.GetType().ToString() == "System.Double")
                        {
                            double d1 = (Double)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                            str = Convert.ToString(d1);
                            keywords.Add(str);
                        }
                        else
                        {
                            str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                            keywords.Add(str);
                        }
                    }
                }
            }
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();
            ReleaseObject(xlWorkSheet);
            ReleaseObject(xlWorkBook);
            ReleaseObject(xlApp);
            return keywords;
        }
    private void ReleaseObject(object obj)
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
