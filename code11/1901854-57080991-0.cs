c#
public static DataTable GetNamedDataTable(SpreadsheetDocument spreadsheetDocument, string DataTableName)
{
    var dataTable = new DataTable();
    Workbook woorkbook = spreadsheetDocument.WorkbookPart.Workbook;
    Sheet sheet = woorkbook.Descendants<Sheet>().Where(s => s.Name == "SheetName").FirstOrDefault();
    SharedStringTable sharedStringTable = woorkbook.WorkbookPart.SharedStringTablePart.SharedStringTable;
    List<SharedStringItem> allSharedStringItems= sharedStringTable.Descendants<SharedStringItem>().ToList();
    WorksheetPart worksheetPart = (WorksheetPart)spreadsheetDocument.WorkbookPart.GetPartById(sheet.Id);
    TableDefinitionPart tableDefinitionPart = worksheetPart.TableDefinitionParts.FirstOrDefault(r => r.Table.Name == DataTableName);
    QueryTablePart queryTablePart = tableDefinitionPart.QueryTableParts.FirstOrDefault();
    Table excelTable = tableDefinitionPart.Table;
    int columnCounter = 0;
    foreach(TableColumn column in excelTable.TableColumns)
    {
       DataColumn dataColumn = dataTable.Columns.Add(column.Name);
       dataColumn.SetOrdinal(columnCounter);
       columnCounter++;
    }
    var newCellRange = excelTable.Reference;
    var startCell = newCellRange.Value.Split(':')[0];
    var endCell = newCellRange.Value.Split(':')[1];
    uint firstRowNum = GetRowIndex(startCell);
    uint lastRowNum = GetRowIndex(endCell);
    string firstColumn = GetColumnName(startCell);
    string lastColumn = GetColumnName(endCell);
    var columnIndex = 0;
    foreach (Row row in worksheetPart.Worksheet.Descendants<Row>().Where(r => r.RowIndex.Value > firstRowNum && r.RowIndex.Value <= lastRowNum))
    {
        var dataRow = dataTable.NewRow();
        foreach (Cell cell in row)
        {                
            string columnName = GetColumnName(cell.CellReference.Value);
            if (CompareColumn(columnName, firstColumn) >= 0 && CompareColumn(columnName, lastColumn) <= 0)
            {
                if (cell.CellValue != null)
                {
                    dataRow[columnIndex] = cell.CellValue.Text;
                }
                columnIndex++;
            }
        }
        dataTable.Rows.Add(dataRow);
        columnIndex = 0;
        Console.WriteLine("");
    }
    return dataTable;
}
private static uint GetRowIndex(string cellName)
{
    // Create a regular expression to match the row index portion the cell name.
    Regex regex = new Regex(@"\d+");
    Match match = regex.Match(cellName);
    return uint.Parse(match.Value);
}
// Given a cell name, parses the specified cell to get the column name.
private static string GetColumnName(string cellName)
{
    // Create a regular expression to match the column name portion of the cell name.
    Regex regex = new Regex("[A-Za-z]+");
    Match match = regex.Match(cellName);
    return match.Value;
}
// Given two columns, compares the columns.
private static int CompareColumn(string column1, string column2)
{
    if (column1.Length > column2.Length)
    {
        return 1;
    }
    else if (column1.Length < column2.Length)
    {
        return -1;
    }
    else
    {
        return string.Compare(column1, column2, true);
    }
}
CREDIT for this answer must go to the following site as it is what lead me to be able to figure this out. https://docs.microsoft.com/en-us/office/open-xml/how-to-calculate-the-sum-of-a-range-of-cells-in-a-spreadsheet-document
