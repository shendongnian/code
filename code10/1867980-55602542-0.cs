public class WorkSheetClass
{
    public int ColumnA { get; set; }
    public int ColumnB { get; set; }
}
then using LinqToExcel
string pathToExcelFile = @"C:\workbook1.xlsx";
string workbookName = "workbook1";
var columnAMaxValue = new ExcelQueryFactory(pathToExcelFile)
                              .Worksheet<WorkSheetClass>(workbookName)
                              .Max(x => x.ColumnA);
