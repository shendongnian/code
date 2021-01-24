	[TestMethod]
	public void Text_Rotate_Test()
	{
		//https://stackoverflow.com/questions/57603348/display-cell-with-vertical-text-using-epplus
		var fileInfo = new FileInfo(@"c:\temp\Text_Rotate_Test.xlsx");
		if (fileInfo.Exists)
			fileInfo.Delete();
		using (var pck = new ExcelPackage(fileInfo))
		{
			var workbook = pck.Workbook;
			var worksheet = workbook.Worksheets.Add("Sheet1");
			var cell = worksheet.Cells[1, 1];
			cell.Value = "Test Text Value";
			//Trigger epplus to create a new style specific for the cell.
			//This needs to be done even thought it will be overridden in 
			//order to ref by index.  But have to be careful not to step
			//on other styles so make it as unique as it needs to be.
			cell.Style.TextRotation = 180;
			//Make sure the update the xml before looking up by index
			workbook.Styles.UpdateXml();
			workbook.Styles.CellXfs[cell.StyleID].TextRotation = 255;
	   
			pck.Save();
		}
	}
