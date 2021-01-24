    using System;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace excelTest
    {
        class Program
        {
            static void Main()
            {
                Excel.Application excel = new Excel.Application
                {
                    Visible = true,
                    DisplayAlerts = false
                };
    
                Excel.Workbook wbk = excel.Workbooks.Add(Type.Missing);
                Excel.Worksheet wks = wbk.Worksheets[1];
    
                Excel.Range cellA1 = wks.Cells[1, 1];
                Excel.Range cellE5 = wks.Cells[5, 5];
                Excel.Range myRange = wks.get_Range(cellA1, cellE5);
    
                int[,] myArray = new int[4, 4];
                for (int col = 0; col < myArray.GetLength(0); col++)
                {
                    for (int row = 0; row < myArray.GetLength(1); row++)
                    {
                        myArray[col, row] = (col + row) * 2;
                    }
                }
                myRange.Value = myArray;
            }
    
