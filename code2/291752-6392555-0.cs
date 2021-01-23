        /// <summary>
        /// This class allows for the easy creation of a simple Excel document who's sole purpose is to contain some export data.
        /// The document is created using OpenXML.
        /// </summary>
        internal class SimpleExcelDocument : IDisposable
        {
            SheetData sheetData;
            
            /// <summary>
            /// Constructor is nothing special because the work is done at export.
            /// </summary>
            internal SimpleExcelDocument()
            {
                sheetData = new SheetData();
            }
            #region Get Cell Reference
            public Cell GetCell(string fullAddress)
            {
                return sheetData.Descendants<Cell>().Where(c => c.CellReference == fullAddress).FirstOrDefault();
            }
            public Cell GetCell(uint rowId, uint columnId, bool autoCreate)
            {
                return GetCell(getColumnName(columnId), rowId, autoCreate);
            }
            public Cell GetCell(string columnName, uint rowId, bool autoCreate)
            {
                return getCell(sheetData, columnName, rowId, autoCreate);
            }
            #endregion
            #region Get Cell Contents
            // See: http://msdn.microsoft.com/en-us/library/ff921204.aspx
            // 
            #endregion
            #region Set Cell Contents
            public void SetValue(uint rowId, uint columnId, bool value)
            {
                Cell cell = GetCell(rowId, columnId, true);
                cell.DataType = CellValues.Boolean;
                cell.CellValue = new CellValue(BooleanValue.FromBoolean(value));
            }
            public void SetValue(uint rowId, uint columnId, double value)
            {
                Cell cell = GetCell(rowId, columnId, true);
                cell.DataType = CellValues.Number;
                cell.CellValue = new CellValue(DoubleValue.FromDouble(value));
            }
            public void SetValue(uint rowId, uint columnId, Int64 value)
            {
                Cell cell = GetCell(rowId, columnId, true);
                cell.DataType = CellValues.Number;
                cell.CellValue = new CellValue(IntegerValue.FromInt64(value));
            }
            public void SetValue(uint rowId, uint columnId, DateTime value)
            {
                Cell cell = GetCell(rowId, columnId, true);
                //cell.DataType = CellValues.Date;
                cell.CellValue = new CellValue(value.ToOADate().ToString());
                cell.StyleIndex = 1;
            }
            public void SetValue(uint rowId, uint columnId, string value)
            {
                Cell cell = GetCell(rowId, columnId, true);
                cell.InlineString = new InlineString(value.ToString());
                cell.DataType = CellValues.InlineString;
            }
            public void SetValue(uint rowId, uint columnId, object value)
            {             
                bool boolResult;
                Int64 intResult;
                DateTime dateResult;
                Double doubleResult;
                string stringResult = value.ToString();
                if (bool.TryParse(stringResult, out boolResult))
                {
                    SetValue(rowId, columnId, boolResult);
                }
                else if (DateTime.TryParse(stringResult, out dateResult))
                {
                    SetValue(rowId, columnId,dateResult);
                }
                else if (Int64.TryParse(stringResult, out intResult))
                {
                    SetValue(rowId, columnId, intResult);
                }
                else if (Double.TryParse(stringResult, out doubleResult))
                {
                    SetValue(rowId, columnId, doubleResult);
                }
                else
                {
                    // Just assume that it is a plain string.
                    SetValue(rowId, columnId, stringResult);
                }
            }
            #endregion
            public SheetData ExportAsSheetData()
            {
                return sheetData;
            }
            public void ExportAsXLSXStream(Stream outputStream)
            {
                // See: http://blogs.msdn.com/b/chrisquon/archive/2009/07/22/creating-an-excel-spreadsheet-from-scratch-using-openxml.aspx for some ideas...
                // See: http://stackoverflow.com/questions/1271520/opening-xlsx-in-office-2003
                              
                using (SpreadsheetDocument package = SpreadsheetDocument.Create(outputStream, SpreadsheetDocumentType.Workbook))
                {
                    // Setup the basics of a spreadsheet document.
                    package.AddWorkbookPart();
                    package.WorkbookPart.Workbook = new Workbook();
                    WorksheetPart workSheetPart = package.WorkbookPart.AddNewPart<WorksheetPart>();
                    workSheetPart.Worksheet = new Worksheet(sheetData);
                    workSheetPart.Worksheet.Save();
                    // create the worksheet to workbook relation
                    package.WorkbookPart.Workbook.AppendChild(new Sheets());
                    Sheet sheet = new Sheet { 
                        Id = package.WorkbookPart.GetIdOfPart(workSheetPart), 
                        SheetId = 1, 
                        Name = "Sheet 1" 
                    };
                    package.WorkbookPart.Workbook.GetFirstChild<Sheets>().AppendChild<Sheet>(sheet);
                    package.WorkbookPart.Workbook.Save();
                    package.Close();
                }
            }
            #region Internal Methods
            private static string getColumnName(uint columnId)
            {
                if (columnId < 1)
                {
                    throw new Exception("The column # can't be less then 1.");
                }
                columnId--;
                if (columnId >= 0 && columnId < 26)
                    return ((char)('A' + columnId)).ToString();
                else if (columnId > 25)
                    return getColumnName(columnId / 26) + getColumnName(columnId % 26 + 1);
                else
                    throw new Exception("Invalid Column #" + (columnId + 1).ToString());
            }
            // Given a worksheet, a column name, and a row index, 
            // gets the cell at the specified column 
            private static Cell getCell(SheetData worksheet,
                      string columnName, uint rowIndex, bool autoCreate)
            {
                Row row = getRow(worksheet, rowIndex, autoCreate);
                if (row == null)
                    return null;
                Cell foundCell = row.Elements<Cell>().Where(c => string.Compare
                       (c.CellReference.Value, columnName +
                       rowIndex, true) == 0).FirstOrDefault();
                if (foundCell == null && autoCreate)
                {
                    foundCell = new Cell();
                    foundCell.CellReference = columnName;
                    row.AppendChild(foundCell);
                }
                return foundCell;
            }
            // Given a worksheet and a row index, return the row.
            // See: http://msdn.microsoft.com/en-us/library/bb508943(v=office.12).aspx#Y2142
            private static Row getRow(SheetData worksheet, uint rowIndex, bool autoCreate)
            {
                if (rowIndex < 1)
                {
                    throw new Exception("The row # can't be less then 1.");
                }
                Row foundRow = worksheet.Elements<Row>().Where(r => r.RowIndex == rowIndex).FirstOrDefault();
                if (foundRow == null && autoCreate)
                {
                    foundRow = new Row();
                    foundRow.RowIndex = rowIndex;
                    worksheet.AppendChild(foundRow);
                }
                return foundRow;
            } 
            #endregion
            #region IDisposable Stuff
            private bool _disposed;
            //private bool _transactionComplete;
            /// <summary>
            /// This will dispose of any open resources.
            /// </summary>
            public void Dispose()
            {
                Dispose(true);
                // Use SupressFinalize in case a subclass
                // of this type implements a finalizer.
                GC.SuppressFinalize(this);
            }
            protected virtual void Dispose(bool disposing)
            {
                // If you need thread safety, use a lock around these 
                // operations, as well as in your methods that use the resource.
                if (!_disposed)
                {
                    if (disposing)
                    {
                        //if (!_transactionComplete)
                        //    Commit();
                    }
                    // Indicate that the instance has been disposed.
                    //_transaction = null;
                    _disposed = true;
                }
            }
            #endregion
        }
