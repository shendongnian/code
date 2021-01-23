    public void ImportData(string _FileName, int _SheetIndex)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = null;
            Excel.Worksheet xlWorksheet = null;
            Excel.Range xlRange = null;
            
            try
            {
                Logger.Write(String.Format("Import Started for File {0}",_FileName));
                xlWorkbook = xlApp.Workbooks.Open(_FileName);
                xlWorksheet = xlWorkbook.Sheets[_SheetIndex];
                xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                object[,] objectArray = (object[,])xlRange.Value[Excel.XlRangeValueDataType.xlRangeValueDefault];
               
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (xlRange != null)
                {
                    Marshal.ReleaseComObject(xlRange);
                }
                if (xlWorksheet != null)
                {
                    Marshal.ReleaseComObject(xlWorksheet);
                }
                if (xlWorkbook != null)
                {
                    xlWorkbook.Close(Excel.XlSaveAction.xlDoNotSaveChanges);
                    Marshal.ReleaseComObject(xlWorkbook);
                }
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                Logger.Write(String.Format("Import End for File {0}", _FileName));
            }
        }
