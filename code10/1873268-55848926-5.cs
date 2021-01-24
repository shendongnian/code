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
    		
    		// Binary serialize the List<string> now to convert it to a stream
    		BinaryFormatter binFormatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            binFormatter.Serialize(memoryStream, res);
    		
    		IBlobManager blobManager = new BlobManager();
    		string newResourceUri = await blobManager.UploadFileToBlobAsync(formFile.FileName, memoryStream);
    		return newResourceUri;
    }
