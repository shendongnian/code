        public void Dispose()
        {
            if(!this.disposed)
            {
                if(cell != null)
                    Marshal.FinalReleaseComObject(cell);
                if(cells != null)
                    Marshal.FinalReleaseComObject(cells);
                if(worksheet != null)
                    Marshal.FinalReleaseComObject(worksheet);
                if(worksheets != null)
                    Marshal.FinalReleaseComObject(worksheets);
                if (workbook != null)
                {
                    workbook.Close(false, Type.Missing, Type.Missing);
                    Marshal.FinalReleaseComObject(workbook);
                }
                Marshal.FinalReleaseComObject(workbooks);
                xlApp.Quit();
                Marshal.FinalReleaseComObject(xlApp);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                disposed = true;
            }
        }
