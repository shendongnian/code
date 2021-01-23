        public class DisposableWorkbook : IDisposable
        {
            private Excel.Workbook _workbook = null;
            public DisposableWorkbook(Excel.Application appXL, String path,
                                      NotSureOfType otherArgument,
                                      Excel.XlFileAccess access)
            {
                _workbook = appXL.Workbooks.Open(path, otherArgument, access);
            }
            public Excel.Workbook Workbook
            {
                get { return _workbook; }
            }
            public void Dispose()
            {
                if (workbook != null)
                {
                    workbook.Close(Excel.XlSaveAction.xlDoNotSaveChanges,
                                   workbookToClose);
                    workbook = null;
                }
            }
        }
        using (DisposableWorkbook dwbXL = new DisposableWorkbook(appXL,
                  _sourceFullPath, Type.Missing, Excel.XlFileAccess.xlReadOnly))
        {
             Excel.Workbook wbXL = dwbXL.Workbook;
             // stuff with wbXL
        }
