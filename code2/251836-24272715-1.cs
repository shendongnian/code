    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Office.Interop.Excel;
    using System.IO;
    namespace TestConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                String fromFile = @"C:\ExlTest\Test.xlsx";
                String toFile = @"C:\ExlTest\csv\Test.csv";
    
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Open(fromFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                
                // this does not throw exception if file doesnt exist
                File.Delete(toFile);
                
                wb.SaveAs(toFile, Microsoft.Office.Interop.Excel.XlFileFormat.xlCSVWindows, Type.Missing, Type.Missing, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges, false, Type.Missing, Type.Missing, Type.Missing);
    
                wb.Close(false,Type.Missing,Type.Missing);
    
                app.Quit();
            }
        }
    }
