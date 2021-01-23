    using Microsoft.Office.Interop.Excel;
    using System.Reflection;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Application xl = null;
                _Workbook wb = null;
    
                // Option 1
                xl = new Application();
                xl.Visible = true;
                wb = (_Workbook)(xl.Workbooks.Add(XlWBATemplate.xlWBATWorksheet));
    
                // Option 2
                xl = new Application();
                xl.SheetsInNewWorkbook = 1;
                xl.Visible = true;
                wb = (_Workbook)(xl.Workbooks.Add(Missing.Value));
    
            }
        }
    }
