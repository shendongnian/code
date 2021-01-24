    namespace ExcelAtSomething
    {
        using System;
        using Excel = Microsoft.Office.Interop.Excel;
    
        class Startup
        {
            static void Main()
            {
                string filePath = @"C:\Users\stackoverflow\Desktop\Sample.xlsx";
                Excel.Application excel = new Excel.Application();
                excel.Visible = true;
                excel.EnableAnimations = true;
    
                Excel.Workbook wkb = Open(excel, filePath);
    
                foreach (Excel.Worksheet xlWorksheet in wkb.Worksheets)
                {
                    Excel.PivotTables pivotTablesCollection = xlWorksheet.PivotTables();
                    if (pivotTablesCollection.Count > 0)
                    {
                        for (int i = 1; i <= pivotTablesCollection.Count; i++)
                        {
                            Excel.PivotTable currentPivotTable = pivotTablesCollection.Item(i);
                            Console.WriteLine($"Table is named -> {currentPivotTable.Name}");
    
                            foreach (Excel.PivotField pivotField in currentPivotTable.PivotFields())
                            {
                                Console.WriteLine($"\nField is named -> {pivotField.Name}");
                                foreach (Excel.PivotItem visibleItems in pivotField.VisibleItems)
                                {
                                    Console.WriteLine($"Visible item name -> {visibleItems.Name}");
                                }
                                
                                foreach (Excel.PivotItem PivotItem in pivotField.PivotItems())
                                {
                                    Console.WriteLine($"Item is named -> {PivotItem.Name}");
                                    Console.WriteLine(PivotItem.Visible);
                                }
                            }
                        }
                    }
                }
    
                excel.EnableAnimations = true;
                wkb.Close(true);
                excel.Quit();
                Console.WriteLine("Finished!");
            }
    
            private static Excel.Workbook Open(Excel.Application excelInstance,
                    string fileName, bool readOnly = false,
                    bool editable = true, bool updateLinks = true)
            {
                Excel.Workbook book = excelInstance.Workbooks.Open(
                    fileName, updateLinks, readOnly,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, editable, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
                return book;
            }
        }
    }
