    [FunctionName("WriteExcelToBlob")]
    public async Task Run(
    	[TimerTrigger("*/30 * * * * *")] TimerInfo timer,
    	[Blob("excelFiles", FileAccess.Write, Connection = "Storage")] CloudBlobContainer blobContainer,
    	ILogger log
    )
    {
    	var fileNameSuffix = DateTime.Now.ToString("yyyyMMdd_HHmmss");
    	
    	var myCollection = new List<MyObject>();
    	
    	var newBlobName = $"myFile_{fileNameSuffix}.xlsx";
    	var newBlob = blobContainer.GetBlockBlobReference(newBlobName);
    	
    	using (var excel = new ExcelPackage())
    	{
    		var worksheet = excel.Workbook.Worksheets.Add("My Worksheet");
    		worksheet.Cells.LoadFromCollection(myCollection);
    		
    		using (var stream = await newBlob.OpenWriteAsync())
    		{
    			excel.SaveAs(stream);
    		}
    	}
    }
