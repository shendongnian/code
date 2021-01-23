    using System;
    
    namespace exceltest2
    {
        using Microsoft.Office.Interop.Excel;
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                Application excel = null;
                Workbook wb = null;
                try
                {
                    // run Excel 
                    excel = new Application();
                    excel.Visible = false;
    
                    // Open file
                    wb = excel.Workbooks.Open(
                        @"D:\test.xlsx", Type.Missing, false, // Read-Only?
                        Type.Missing, Type.Missing, Type.Missing, 
                        Type.Missing, Type.Missing, Type.Missing, 
                        Type.Missing, Type.Missing, Type.Missing, 
                        Type.Missing, Type.Missing, Type.Missing);
    
                    // Read worksheets
                    Sheets sheets = wb.Worksheets;
    
                    // Select worksheets
                    Worksheet ws = (Worksheet)sheets.get_Item("Table1");
    
                    Range range = (Range)ws.get_Range("A1", "A1");
    
                    // Check Values #1
                    Console.WriteLine(ws.get_Range("A1", "A1").Value2.ToString());
                    Console.WriteLine(ws.get_Range("A2", "A2").Value2.ToString());
    
                    range.Cells[1, 1] = 15;
    
                    // Check Values #2
                    Console.WriteLine(ws.get_Range("A1", "A1").Value2.ToString());
                    Console.WriteLine(ws.get_Range("A2", "A2").Value2.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    wb.Save();
                    wb.Close(false, null, null);
                    excel.Quit();
                    Console.ReadLine();
                }
            }
        }
    }
