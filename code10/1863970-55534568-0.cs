    using (SpreadsheetDocument document = SpreadsheetDocument.Open(filePath, false))
    {
        WorkbookPart workbookPart = document.WorkbookPart;
        WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
        SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
        SharedStringTablePart stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
        var rows = sheetData.Descendants<Row>();
        foreach (Row row in rows)
        {
            if (row.RowIndex <= skipRows)
            {
                continue;
            }
			//this is just to show that it's outputting from the first non-skipped row
            Cell cell = row.GetFirstChild<Cell>();
            string contents;
            if (cell.DataType == CellValues.SharedString)
            {
                int index = int.Parse(cell.CellValue.InnerText);
                contents = stringTable.SharedStringTable.ElementAt(index).InnerText;
            }
            else
            {
                contents = cell.InnerText;
            }
            Console.WriteLine(contents);
        }
    }
