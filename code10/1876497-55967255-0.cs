	internal List<string> GetDataToTranslate(string filePath)
	{
		using (StreamReader fileReader = new StreamReader(...))
		{
			return GetDataToTranslate(fileReader);
		}
	}
	internal List<string> GetDataToTranslate(TextReader reader)
	{
		List<string> dataToTranslate = new List<string>();
		// ... your code
		
		return dataToTranslate;    
	}
