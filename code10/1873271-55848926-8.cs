    public async Task<string> ValidateDataFileAsync(IFormFile formFile)
    {
    		List<string> result = new List<string>();
    		
    		using (var reader = new StreamReader(formFile.OpenReadStream()))
    		{
    			//read till EOF
    			while (reader.Peek() >= 0)
    				result.Add(reader.ReadLineAsync().Result);
    		}
    
    		// Filter by repeated items
    		result = result.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key).ToList();
    		
    		// Write the List<string> into the MemoryStream using the EPPlus package
    		
    		MemoryStream memoryStream = new MemoryStream();
    		using (var package = new ExcelPackage())
    		{
    			var worksheet = package.Workbook.Worksheets.Add("Worksheet 1");
    			worksheet.Cells["A1"].LoadFromCollection(result);
    			memoryStream = new MemoryStream(package.GetAsByteArray());
    		}
    		
    		IBlobManager blobManager = new BlobManager();
    		string newResourceUri = await blobManager.UploadFileToBlobAsync(formFile.FileName, memoryStream);
    		return newResourceUri;
    }
