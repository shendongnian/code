    using (var zip = ZipFile.Open("ExcelWorkbookWithMacros.xlsm", ZipArchiveMode.Update))
    {
    	var entry = zip.GetEntry("xl/_rels/workbook.xml.rels");
    	if (entry != null)
    	{
    		var tempFile = Path.GetTempFileName();
    		entry.ExtractToFile(tempFile, true);
    		var content = File.ReadAllText(tempFile);
    		[...]
    	}
    }
