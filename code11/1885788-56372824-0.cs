    using Microsoft.Office.Interop.Excel;
    //..
    Excel.Application excel = new Excel.Application();
    Workbook book = excel.Workbooks.Add();
    Worksheet sheet = book.Sheets.Item[1];
    try
    {
        //int i = 2;
        //foreach ()
        //{
        //sheet.Cells[i, 1] = ...;
        //i++;
        //}
    }
    catch { }
    finally
    {
        book.Close(true, @"path");
        excel.Quit();
    }
    Console.Read();
