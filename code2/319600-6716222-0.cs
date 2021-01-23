     private void EXCELTOCSV()
        {
            OpenFileDialog excelSheetToOpen = new OpenFileDialog();
            excelSheetToOpen.Filter = "Excel 97- 2003 WorkBook (*.xls)| *.xls | Excel 2007 WorkBook (*.xlsx) | *.xlsx | All files (*.*)|*.*";
            excelSheetToOpen.FilterIndex = 3;
            excelSheetToOpen.Multiselect = false;
            if (excelSheetToOpen.ShowDialog() == DialogResult.OK)
            {
                Excel.Application excelApp = new Excel.Application();
                String workbookPath = excelSheetToOpen.FileName;
                Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(workbookPath);
                Excel.Sheets excelWorkBookSheets = excelWorkbook.Sheets;
                Excel.Range _UsedRangeOftheWorkSheet;
                foreach (Excel.Worksheet _Sheet in excelWorkBookSheets)
                {
                    if (_Sheet.Name =="ExcelSheetName")
                    {
                       
                        _UsedRangeOftheWorkSheet = _Sheet.UsedRange;
                        Object[,] s = _UsedRangeOftheWorkSheet.Value;
                        System.IO.StreamWriter sw = new System.IO.StreamWriter("FileName.csv", true);
                        for (int b = 0; b < s.Length; b++)
                        {
                            StringBuilder sb = new StringBuilder();
                            for (int c = 0; c < s.Rank; c++)
                            {
                                if (sb == null)
                                {
                                    sb.Append((String)s[b, c]);
                                }
                                else
                                {
                                    sb.Append("," + (String)s[b, c]);
                                }
                            }
                            sw.WriteLine(sb.ToString());
                        }
                        sw.Close();
                    }
                }
            }
        }
