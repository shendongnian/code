    using Excel = Microsoft.Office.Interop.Excel;
    
     static void Main(string[] args)
            {
                string pathToExcelFile = @"D:\test.xlsx";
    
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(pathToExcelFile, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
    
                Excel._Worksheet sheet = (Excel._Worksheet)xlWorkbook.Sheets[1];
                Excel.Range ran = sheet.UsedRange;
                for (int x = 1; x <= ran.Rows.Count; x++)
                {
                    for (int y = 1; y <= ran.Columns.Count; y++)
                    {
                        var CellColor = sheet.UsedRange.Cells[x, y].Interior.Color; 
                        if(CellColor==GetCustomColor(Color.Red))
                        {
                            string value = sheet.Cells[x, y].value.ToString();
                            Console.WriteLine(value);
                        }
                    }
                }
                Console.ReadKey();
            }
            private static  Double GetCustomColor(Color color)
            {
                int nColor = color.ToArgb();
                int blue = nColor & 255;
                int green = nColor >> 8 & 255;
                int red = nColor >> 16 & 255;
                return Convert.ToDouble(blue << 16 | green << 8 | red);
            }
