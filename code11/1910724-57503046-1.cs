cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = @"D:\Test.xlsx";
            Excel.Application ExcelApp = new Excel.Application();
            Excel.Workbook ExcelWorkbook = ExcelApp.Workbooks.Open(inputFile);
            Excel.Range formatRange;
            ExcelApp.Visible = true;
            foreach (Excel.Worksheet ExcelWorksheet in ExcelWorkbook.Sheets)
            {
                ExcelWorksheet.Select(Type.Missing);
                ExcelWorksheet.Columns[1].NumberFormat = "";
                ExcelWorksheet.Columns[2].NumberFormat = "yyyy-MM-dd"; // convert format to date
                ExcelWorksheet.Columns[2].NumberFormat = "";
                ExcelWorksheet.Columns[3].NumberFormat = "0.00000"; // convert format to decimal with 5 decimal digits
                ExcelWorksheet.Columns[3].NumberFormat = "";
                ExcelWorksheet.Columns[4].NumberFormat = "";
            }
            ExcelWorkbook.Save();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            ExcelWorkbook.Close(Type.Missing, Type.Missing, Type.Missing);
            Marshal.FinalReleaseComObject(ExcelWorkbook);
            ExcelApp.Quit();
            Marshal.FinalReleaseComObject(ExcelApp);
        }
    }
}
After executing the application, the Excel looked like the following:
[![enter image description here][2]][2]
### Discussion and Conclusion
From the image above, we can see that all columns are changed to General Number format, but if values are stored as numbers they will be shown as they are stored: Date values are shown as Excel serials (numbers), decimal values are shown with only one decimal digit, even if we changed the format to five digits before resetting the format to General.
In Brief, you cannot handle how the values are shown when the Number Format is "General", if you need to show values as dates you have to set the number format to `yyyy-MM-dd` or any other date format.
## Reference
- https://stackoverflow.com/questions/7724403/c-sharp-accessing-excel-formatting-cell-as-general
---------------------
## Update 1
Instead of using `ExcelWorksheet.Columns[1].NumberFormat`, try using the following code:
csharp
ExcelWorksheet.Cells[1,1].EntireColumn.NumberFormat = "";
ExcelWorksheet.Cells[1,2].EntireColumn.NumberFormat = "";
  [1]: https://i.stack.imgur.com/nqndY.png
  [2]: https://i.stack.imgur.com/Bik6c.png
