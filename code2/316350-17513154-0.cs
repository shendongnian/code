    private void readExcel()  
             {  
                object _row = 1;  
                object _column = 1;  
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();  
              excelApp.Visible = false;  
              excelApp.ScreenUpdating = false;  
              excelApp.DisplayAlerts = false;  
              Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(@"D:\\Book1.xlsx", 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);  
              Microsoft.Office.Interop.Excel.Sheets excelSheets = excelWorkbook.Worksheets;
              string currentSheet = "Sheet1";  
              Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelSheets.get_Item(currentSheet);  
              Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)excelWorksheet.UsedRange;  
              string sValue = (range.Cells[_row, _column] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();  
              //sValue has your value  
             }
