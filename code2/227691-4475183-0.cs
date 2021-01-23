    using System;
    using System.IO;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var stream = new FileStream(@"c:\my_workbook.xls", FileMode.Open);
                var workbook = new HSSFWorkbook(stream);
                stream.Close();
    
                var sheet = workbook.GetSheet("My Sheet Name");
                var row_enumerator = sheet.GetRowEnumerator();
    
                while (row_enumerator.MoveNext())
                {
                    var row = (Row)row_enumerator.Current;
                    var cell = row.GetCell(1); // in Excel, indexes are 1-based; in NPOI the indexes are 0-based
                    Console.WriteLine(cell.StringCellValue);
                }
    
                Console.ReadKey();
            }
        }
    }
