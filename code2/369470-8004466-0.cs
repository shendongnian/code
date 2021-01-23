       class ExcelParser : IDisposable
    {
        bool disposed = false;
        Application _excelApp = null;
        Workbooks workBooks = null;
        Workbook workBook = null;
        Sheets wSheets = null;
        Worksheet wSheet = null;
        Range xlRange = null;
        Range xlRowRange = null;
        Range xlcolRange = null;
        public bool Load(string filePath)
        {
            bool bFlag = true;
            try
            {
                _excelApp = new Application();
                workBooks = _excelApp.Workbooks;
                workBook = workBooks.Open(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                        Type.Missing, Type.Missing);
                wSheets = (Sheets)workBook.Sheets;
                wSheet = (Worksheet)wSheets.get_Item(1);
                xlRange = wSheet.UsedRange;
                xlRowRange = xlRange.Rows;
                xlcolRange = xlRange.Columns;
            }
            catch (Exception exp)
            {
                throw;
            }
            return bFlag;
        }
        public int GetRowCount()
        {
            int rowCount = 0;
            if(xlRowRange != null)
                rowCount = xlRowRange.Count;
            return rowCount;
        }
        public string GetValue(int rowIndex, int colIndex)
        {
            string value = "";
            Range cell = null;
            try
            {
                cell = xlRange.Cells[rowIndex, colIndex] as Range;
                object val = cell.Value2;
                value = val.ToString();                
            }
            catch (Exception exp)
            {
            }
            finally
            {
                Marshal.ReleaseComObject(cell);
            }
            return value;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            { // don't dispose more than once
                if (disposing)
                {
                    // disposing==true means you're not in the finalizer, so
                    // you can reference other objects here
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    if (workBook != null)
                        workBook.Close(false, Type.Missing, Type.Missing);
                    if (_excelApp != null)
                        _excelApp.Quit();
                    if (xlRowRange != null)
                        Marshal.ReleaseComObject(xlRowRange);
                    if (xlRange != null)
                        Marshal.ReleaseComObject(xlRange);
                    if (xlcolRange != null)
                        Marshal.ReleaseComObject(xlcolRange);
                    if (wSheet != null)
                        Marshal.ReleaseComObject(wSheet);
                    if (wSheets != null)
                        Marshal.ReleaseComObject(wSheets);
                    if (workBook != null)
                        Marshal.ReleaseComObject(workBook);
                    if (workBooks != null)
                        Marshal.ReleaseComObject(workBooks);
                    if (_excelApp != null)
                        Marshal.ReleaseComObject(_excelApp);
                }              
                
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);            
        }
        ~ExcelParser()
        {
            Dispose(false);
        }
    }
