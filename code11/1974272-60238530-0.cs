	[TestMethod]
	[ExpectedException(typeof(Exception))]
	public void findExcelSheet_Test()
	{
		// arrange
		ExcelPackage testSpreadsheet = new ExcelPackage();
		ExcelWorksheet testWsFPS = testSpreadsheet.Workbook.Worksheets.Add("FPS");
		ExcelWorksheet testWsDRS = testSpreadsheet.Workbook.Worksheets.Add("DRS");
		ExcelWorksheet testWsDPC = testSpreadsheet.Workbook.Worksheets.Add("DPC");
		// act
		findExcelSheet(testSpreadsheet, Path.GetRandomFileName()); //or some other random string
		// assert
	}
