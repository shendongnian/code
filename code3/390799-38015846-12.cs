    public static string ExportDataToExcel(DataTable dataTable, string directoryPath, string fileName_withoutExt, bool skipComplexObjects, bool skipInheritedProps, string[] skipProps = null)
    {
    	if (directoryPath[directoryPath.Length - 1] == '\\') // no need to check for >0 length. let it throw an exection for that
    		directoryPath = directoryPath + "\\";
    
    	using (var spreadSheet = new SpreadsheetControl())
    	{
    		// Create new excel document and import the datatable to the worksheet
    		spreadSheet.CreateNewDocument();
    		spreadSheet.BeginUpdate();
    		var worksheet = spreadSheet.Document.Worksheets.ActiveWorksheet;
    		worksheet.Import(source: dataTable, addHeader: true, firstRowIndex: 0, firstColumnIndex: 0);
    
    		// applying style on header
    		Range range = worksheet.Range["A1:" + worksheet.Columns[worksheet.Columns.LastUsedIndex].Heading+"1"];
    		Formatting rangeFormatting = range.BeginUpdateFormatting();
    		rangeFormatting.Fill.BackgroundColor = System.Drawing.Color.LightSteelBlue;
    		rangeFormatting.Font.FontStyle = SpreadsheetFontStyle.Bold;
    		range.AutoFitColumns();
    		range.EndUpdateFormatting(rangeFormatting);
    
    		spreadSheet.EndUpdate();
    		fileName_withoutExt += ".xlsx";
    		Directory.CreateDirectory(directoryPath); // if directory already exists, CreateDirectory will do nothing
    		spreadSheet.SaveDocument(directoryPath + fileName_withoutExt, DocumentFormat.OpenXml);
    
    		return directoryPath + fileName_withoutExt;
    	}
    }
