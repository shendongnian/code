            using System;
            using Excel = Microsoft.Office.Interop.Excel;
           
            class Program
            {
                static void Main(string[] args)
                {
                    var excelApplication = new Excel.Application { Visible = false, DisplayAlerts = false };
                    Excel.Workbook excelWorkBook = excelApplication.Workbooks.Open(Filename: @"C:\temp\YourTemplate.xlsx");
                    Excel.Worksheet targetedExcelSheet = (Excel.Worksheet)excelApplication.ActiveWorkbook.Sheets[1];
                    Excel.Range ATrialRange = targetedExcelSheet.Range["F4", Type.Missing];
                    ATrialRange.Value2 = "The values that you have parsed from your html string";
                    excelWorkBook.SaveAs(Filename: @"C:\temp\YourNewlyGenerated.xlsx");
                    excelWorkBook.Close();
                    excelApplication.Quit();    
                }
            }
