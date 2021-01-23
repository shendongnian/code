    using (FileStream fileStream = File.Open(inputFilenames[0], FileMode.Open, FileAccess.Read))
    {
    	IExcelDataReader excelReader;
    	if (Path.GetExtension(inputFilenames[0]) == ".xls")
    		excelReader = Factory.CreateReader(fileStream, ExcelFileType.Binary);
    	else
    		excelReader = Factory.CreateReader(fileStream, ExcelFileType.OpenXml);
    
    	excelReader.NextResult();
    	while (excelReader.Name != this.Worksheet)
    		excelReader.NextResult();                
    	
    	while (excelReader.Read())
    	{
    		if (FirstRowHasColumnNames)
    		{
    			FirstRowHasColumnNames = false;
    		}
    		else
    		{
    			//do stuff
    			var test = GetColumnData(excelReader, 1);
    		}
    	}
    
    	this.Save(outputFilename);
    }
