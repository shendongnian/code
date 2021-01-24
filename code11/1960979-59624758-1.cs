Excel.Application app;
Excel.Workbook wb;
private void openAndRead()
{
 app = new Excel.Application();
 wb = app.Workbooks.Open(YourFileHere);
//do stuff here read or write
//app.ActiveSheet.Cells[1, "A"] = "write this in cell A1";
//string read= app.ActiveSheet.Cells[1, "A"]; 
}
private void closeExcel ()
{
 app.DisplayAlerts = false; //this will stop popup questions from excel
 wb.Close();
 app.Quit();
}
