    private void GetExcelData(string fullPath, List<double> arrForValues)
            {
                Excel.Application excelapp = new Excel.Application();
                excelapp.Visible = false;
                // to avoid appearing of Excel window on the screen
                Excel.Workbook excelappworkbook = excelapp.Workbooks.Open(
                    fullPath,
                    Type.Missing, Type.Missing, true, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
                Excel.Worksheet excelworksheet = (Excel.Worksheet)excelappworkbook.Worksheets.get_Item(1);
                Excel.Range excelcells = excelworksheet.UsedRange;
                object[,] worksheetValuesArray = excelcells.get_Value(Type.Missing);
                
                for (int col = 1; col < (worksheetValuesArray.GetLength(1)+1); col++)
                {
                    for (int row = 1; row < (worksheetValuesArray.GetLength(0)+1); row++)
                    {
                        arrForValues.Add((double) worksheetValuesArray[row, col]);
                    }
                }
                excelappworkbook.Close(false, Type.Missing, Type.Missing);
                excelapp.Quit();
            }
