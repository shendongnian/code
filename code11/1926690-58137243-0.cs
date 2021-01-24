        public  void CheckExcelColumnName(string sourceFile)
        {
                if (!System.IO.File.Exists(sourceFile))
                {
                throw new System.ArgumentException("source file is missing");
                }
            try
            {
                Type excelType = Type.GetTypeFromProgID("Excel.Application");
                dynamic excel = Activator.CreateInstance(excelType);
                if (excel == null)
                {
                    throw new System.Exception("Excel is missing");
                }
                excel.Workbooks.Open(sourceFile);
                try
                {
                    dynamic workbook = excel.Workbooks[1];
                    dynamic worksheets = workbook.Sheets;
                    dynamic worksheet = worksheets[1];
                    dynamic cells = worksheet.Cells;
                    int xlCellTypeLastCell = 11;
                    dynamic lastfilledcell = cells.SpecialCells(xlCellTypeLastCell, Type.Missing);
                    int lastcolumn = lastfilledcell.Column;
                    dynamic range = worksheet.Range("A1", "A1");//
                    var v = range.EntireRow.Value;
                    for(int c=1;c<= lastcolumn;c++)
                    {
                        if ( v[1,c]==null)
                        {
                            Console.WriteLine("excel sheet is missing column name for column #" + c);
                            break;
                        }
                    }
                    workbook.Close();
                    lastfilledcell = null;
                    cells = null;
                    range = null;
                    worksheet = null;
                    worksheets = null;
                    workbook = null;
                }
                catch {; }
                excel.Quit();
                //try { System.Runtime.InteropServices.Marshal.ReleaseComObject(excel); } catch {; }
                try { System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excel); } catch {; }
                excel = null;
            }
            catch(Exception ex)
            {
            }
        }
