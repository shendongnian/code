            Excel.Application ExcelApp = new Excel.Application();
            Excel.Workbook ExcelWorkbook = ExcelApp.Workbooks.Open(ResultsFilePath);
            ExcelApp.Visible = true;
            //Looping through all available sheets
            foreach (Excel.Worksheet ExcelWorksheet in ExcelWorkbook.Sheets)
            {                
                //Selecting the worksheet where we want to perform action
                ExcelWorksheet.Select(Type.Missing);
                //Making sure first row is selected - else split and freeze will happen
                //On the visible part and not from the top
                Excel.Range activeCell = ExcelWorksheet.Cells[1, 1];
                activeCell.Select();
                //Applying auto filter to Row 10
                activeCell = (Excel.Range)ExcelWorksheet.Rows[10];
                activeCell.AutoFilter(1,
                    Type.Missing,
                    Excel.XlAutoFilterOperator.xlAnd,
                    Type.Missing,
                    true);
                //Split the pane and freeze it
                ExcelWorksheet.Application.ActiveWindow.SplitRow = 10;
                ExcelWorksheet.Application.ActiveWindow.FreezePanes = true;
                //Auto fit all columns
                ExcelWorksheet.Columns.AutoFit();
                //Releasing range object
                Marshal.FinalReleaseComObject(activeCell);
            }
            //saving excel file using Interop
            ExcelWorkbook.Save();
            //closing file and releasing resources
            ExcelWorkbook.Close(Type.Missing, Type.Missing, Type.Missing);
            Marshal.FinalReleaseComObject(ExcelWorkbook);
            ExcelApp.Quit();
            Marshal.FinalReleaseComObject(ExcelApp);
