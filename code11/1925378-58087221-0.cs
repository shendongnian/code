    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Excel = Microsoft.Office.Interop.Excel;
    
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string aux = readEDriver();
                Console.WriteLine(aux);
                Console.ReadLine();
            }
            public static string readEDriver()
            {
                int nRows = 1;
                int nCols = 1;
                String driverLoc = null;
                Excel.Application excelApp = new Excel.Application();
                if (excelApp != null)
                {
                    Excel.Workbook excelWorkbook;
                    excelWorkbook = excelApp.Workbooks.Open("C:/Users/Usuario/Desktop/PruebasTxtFile.xlsx", 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    Excel.Worksheet excelWorksheet;
                    excelWorksheet = (Excel.Worksheet)excelWorkbook.Worksheets[1];
                    excelWorksheet.Activate();
                    String eName = excelWorksheet.Name;
                    if (excelWorksheet == null)
                    {
                        throw new Exception(string.Format("Named worksheet ({0}) not found.", excelWorksheet));
                    }
                    else
                    {
                        var cellVal = ((Microsoft.Office.Interop.Excel.Range)excelWorksheet.Cells[nRows, nCols]).Value2;
    
                        if (excelWorksheet.Cells[nRows, nCols] != null)
                        {
                            cellVal = ((Microsoft.Office.Interop.Excel.Range)excelWorksheet.Cells[nRows, nCols]).Value2;
                            driverLoc = cellVal.ToString();
                        }
                    }
    
                    excelWorkbook.Close();
                    excelApp.Quit();
                }
                return driverLoc;
            }
        }
    }
