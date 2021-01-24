    using (var workbook = SpreadsheetDocument.Create(Savepath, SpreadsheetDocumentType.Workbook))
    {
        var workbookPart = workbook.AddWorkbookPart();
        workbook.WorkbookPart.Workbook = new Workbook();
        workbook.WorkbookPart.Workbook.Sheets = new Sheets();
		
		//declare our MergeCells here
		MergeCells mergeCells = null;
		
        foreach (DataRow dsrow in table.Rows)
        {
            int innerColIndex = 0;
            rowIndex++;
            Row newRow = new Row();
            foreach (String col in columns)
            {
                Stylesheet stylesheet1 = new Stylesheet();
                Cell cell = new Cell();
                cell.DataType = CellValues.String;
                cell.CellValue = new CellValue(dsrow[col].ToString());
                cell.CellReference = excelColumnNames[innerColIndex] + rowIndex.ToString();
                if (table.TableName == "Work Order Report")
                {
                    string cellNameWorkOrder = dsrow[col].ToString();
                    if (cellNameWorkOrder == "POSTER: 10% MUST HAVE APPROACH AND CLOSE-UP SHOTS - PHOTO OF EACH CREATIVE" || cellNameWorkOrder == "BULLETINS: 100% CLOSE-UP AND APPROACH OF EACH UNIT")
                    {
						if (mergeCells == null)
							mergeCells = new MergeCells();
							
                        var cellAddress = cell.CellReference;
                        var cellAddressTwo = "I" + rowIndex.ToString();
                        mergeCells.Append(new MergeCell() { Reference = new StringValue(cellAddress + ":" + cellAddressTwo) });
                    }
                }
                newRow.AppendChild(cell);
                innerColIndex++;
            }
            sheetData.AppendChild(newRow);
        }
		//add the mergeCells to the worksheet if we have any
		if (mergeCells != null)
			sheetPart.Worksheet.InsertAfter(mergeCells, sheetPart.Worksheet.Elements<SheetData>().First());
    }
