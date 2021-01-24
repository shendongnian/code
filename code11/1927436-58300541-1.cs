    public static byte[] GetRejectsExcelFile(string userId)
    		{
    			List<RejectsModel> rejectList = GetFactureFournisseur(userId);
			using (MemoryStream mem  = new MemoryStream())
			{
				SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(mem, SpreadsheetDocumentType.Workbook);
				// Add a WorkbookPart to the document.
				WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
				workbookpart.Workbook = new Workbook();
				// Add a WorksheetPart to the WorkbookPart.
				WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
				SheetData sheetData = new SheetData();
				worksheetPart.Worksheet = new Worksheet(sheetData);
				// Add Sheets to the Workbook.
				Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.
					AppendChild<Sheets>(new Sheets());
				// Append a new worksheet and associate it with the workbook.
				Sheet sheet = new Sheet()
				{
					Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
					SheetId = 1,
					Name = "Invoices"
				};
				Row row = new Row() { RowIndex = 1 };
				Cell header1 = new Cell() { CellReference = "A1", CellValue = new CellValue("Business"), DataType = CellValues.String };
				row.Append(header1);
				Cell header2 = new Cell() { CellReference = "B1", CellValue = new CellValue("Supplier code"), DataType = CellValues.String };
				row.Append(header2);
				Cell header3 = new Cell() { CellReference = "C1", CellValue = new CellValue("Supplier"), DataType = CellValues.String };
				row.Append(header3);
				sheetData.Append(row);
				uint rowIndex = 1;
				foreach(var ff in rejectList)
				{
					++rowIndex;
					Row dataRow = new Row() { RowIndex = rowIndex };
					dataRow.Append(new Cell() { CellReference = "A" + rowIndex.ToString(), CellValue = new CellValue(ff.BusinessName), DataType = CellValues.String });
					dataRow.Append(new Cell() { CellReference = "B" + rowIndex.ToString(), CellValue = new CellValue(ff.SupplierCode), DataType = CellValues.String });
					dataRow.Append(new Cell() { CellReference = "C" + rowIndex.ToString(), CellValue = new CellValue(ff.SupplierName), DataType = CellValues.String });
					sheetData.Append(dataRow);
				}
				sheets.Append(sheet);
				workbookpart.Workbook.Save();
				// Close the document.
				spreadsheetDocument.Close();
				return mem.ToArray();
			}
		}
