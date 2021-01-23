    protected void Export()
    {
        Response.ClearHeaders();
        Response.ClearContent();
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml";
        //"application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml" '"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" '"application/vnd.ms-excel"
        Response.AddHeader("content-disposition", "attachment; filename=Test.xlsx");
        Response.Charset = "";
        this.EnableViewState = false;
        MemoryStream ms = new MemoryStream();
        SpreadsheetDocument objSpreadsheet = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
        WorkbookPart objWorkbookPart = objSpreadsheet.AddWorkbookPart();
        objWorkbookPart.Workbook = new Workbook();
        WorksheetPart objSheetPart = objWorkbookPart.AddNewPart<WorksheetPart>();
        objSheetPart.Worksheet = new Worksheet(new SheetData());
        Sheets objSheets = objSpreadsheet.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
        Sheet objSheet = new Sheet();
        objSheet.Id = objSpreadsheet.WorkbookPart.GetIdOfPart(objSheetPart);
        objSheet.SheetId = 1;
        objSheet.Name = "mySheet";
        objSheets.Append(objSheet);
       
        for (int intRow = (int)('A'); intRow <= (int)('Z'); intRow++)
        {
            for (uint intCol = 1; intCol <= 5; intCol++)
            {
                Cell objCell = InsertCellInWorksheet(Convert.ToString((char)intRow), intCol, objSheetPart);
                objCell.CellValue = new CellValue("This was a test: " + Convert.ToString((char)intRow) + intCol.ToString());
                objCell.DataType = new EnumValue<CellValues>(CellValues.String);
            }
        }
        objSheetPart.Worksheet.Save();
        objSpreadsheet.WorkbookPart.Workbook.Save();
        objSpreadsheet.Close();
        ms.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
    }
    private static Cell InsertCellInWorksheet(string columnName, uint rowIndex, WorksheetPart worksheetPart)
    {
        Worksheet worksheet = worksheetPart.Worksheet;
        var sheetData = worksheet.GetFirstChild<SheetData>();
        string cellReference = columnName + rowIndex;
        // If the worksheet does not contain a row with the specified row index, insert one.
        Row row;
        if (sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
        {
            row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
        }
        else
        {
            row = new Row { RowIndex = rowIndex };
            sheetData.Append(row);
        }
        // If there is not a cell with the specified column name, insert one.  
        if (row.Elements<Cell>().Where(c => c.CellReference.Value == columnName + rowIndex).Count() > 0)
        {
            return row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).First();
        }
        // Cells must be in sequential order according to CellReference. Determine where to insert the new cell.
        Cell refCell = row.Elements<Cell>().FirstOrDefault(cell => string.Compare(cell.CellReference.Value, cellReference, true) > 0);
        var newCell = new Cell { CellReference = cellReference };
        row.InsertBefore(newCell, refCell);
        
        //worksheet.Save();
        return newCell;
    }
