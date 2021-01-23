    public class ObjectParser<T>
    {
        public List<T> ParseObject(string filePath, Func<Range, T> f)       
        {       
            Application _excelApp = null;       
            Workbooks workBooks = null;       
            Workbook workBook = null;       
            Sheets wSheets = null;       
            Worksheet wSheet = null;       
            Range xlRange = null;       
            Range xlRowRange = null;       
            Range xlcolRange = null;       
            List<T> lst= new List<T>();       
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
                xlRowRange  = xlRange.Rows;       
                xlcolRange = xlRange.Columns;       
       
                int rowCount = xlRowRange.Count;       
                int colCount = xlcolRange.Count;       
       
                for (int i = 2; i <= rowCount; i++)       
                {          
                   lst.Add(f(xlRange));
                }       
       
            }       
            catch (Exception exp)       
            {       
            }       
            finally       
            {       
                GC.Collect();       
                GC.WaitForPendingFinalizers();       
       
                workBook.Close(false, Type.Missing, Type.Missing);                       
                _excelApp.Quit();       
       
       
                Marshal.ReleaseComObject(xlRowRange);       
                Marshal.ReleaseComObject(xlRange);       
                Marshal.ReleaseComObject(xlcolRange);       
                Marshal.ReleaseComObject(wSheet);       
                Marshal.ReleaseComObject(wSheets);                       
                Marshal.ReleaseComObject(workBook);       
                Marshal.ReleaseComObject(workBooks);       
       
                Marshal.ReleaseComObject(_excelApp);       
       
            }       
       
       
            return lst;       
        }       
    }
