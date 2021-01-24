    using Microsoft.Office.Interop.Excel;
    using System.Collections.Generic;
    using System.Linq;
    namespace ExcelInteropDotNet
    {
        public class CompanyStockInfo
        {
            public string StockSymbol { get; set; }
            public string CompanyName { get; set; }
            public string SPSector { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                // Change the below variabes to the relevant values for your needs.
                string workbookName = @"c:\temp\Source Data.xlsx";
                string worksheetName = "CompanyStockData";
                // Create a new list with the type being the CompanyStockInfo type.
                var companyStockInfoList = new List<CompanyStockInfo>();
                // Create an instance of Excel, open the workbook, fetch the sheet and then
                // find the last row in column A.
                var xlApplication = new Application();
                var xlWorkbook = xlApplication.Workbooks.Open(workbookName, ReadOnly: true);
                var xlSrcSheet = xlWorkbook.Worksheets[worksheetName] as Worksheet;
                var lastRow = xlSrcSheet.Cells[xlSrcSheet.Rows.Count,1].End[XlDirection.xlUp].Row;
                // There may be a better way to do this but essentially, the below will loop through
                // all cells from the 2nd row to the last row and create a new item in the list
                // that stores all of the data.
                for (long row = 2; row <= lastRow; row++)
                {
                    companyStockInfoList.Add(new CompanyStockInfo()
                    {
                        StockSymbol = (xlSrcSheet.Cells[row, 1] as Range).Text,
                        CompanyName = (xlSrcSheet.Cells[row, 2] as Range).Text,
                        SPSector = (xlSrcSheet.Cells[row, 3] as Range).Text
                    });
                }
                xlApplication.Quit();
                // You can use Linq to sort and search the list for the data you're wanting to
                // get your hands on.
                // Will filter all entries that have Inc. in the company name.
                var filteredList = companyStockInfoList.Where(item => item.CompanyName.Contains("Inc."));
                // Orders all entries by the company name in alphabetical order.
                var orderedList = companyStockInfoList.OrderBy(item => item.CompanyName);
            }
        }
    }
