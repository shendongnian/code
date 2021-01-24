    public void CopyValues()
            {
                Excel.Application excelApp = new Excel.Application();
                if (excelApp != null)
                {
                    Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(@"C:\test.xls", 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
    
                    Excel.Range excelRange = excelWorksheet.UsedRange;
                    int rowCount = excelRange.Rows.Count;
                    int colCount = excelRange.Columns.Count;
    
                    Excel.Range copyRange = null;
    
                    for (int i = 1; i <= rowCount; i++)
                    {
                        for (int j = 1; j <= colCount; j++)
                        {
                            Excel.Range range = (excelWorksheet.Cells[i, j] as Excel.Range);
                            if (range.Value.ToString().Trim() != string.Empty)
                            {
                                if (copyRange == null)
                                {
                                    copyRange = range;
                                }
                                else
                                {
                                    //Its got somehting so union it in
                                    copyRange = excelApp.Union(copyRange, range);
                                }
                            }
    
                            
                        }
                    }
                    //Copy to clipboard
                    copyRange.Copy();
    
                    excelWorkbook.Close();
                    excelApp.Quit();
                }
            }
