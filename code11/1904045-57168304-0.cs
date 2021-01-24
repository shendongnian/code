	public async Task<string> UploadAssets(IFormFile file, string fileName)
		{
			string storePath = "";
			try
			{
				storePath = Path.Combine(_assetSettings.Value.StorePath, $"{fileName}.{file.ContentType.Split("/")[1]}");
				using (var stream = new FileStream(storePath, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}
             }
      }
