    class FileWriter
    {
        string filename;
    
        public FileWriter()
        {
    
        }
    
        public void SetFilename(string filename)
        {
            this.filename = filename;
        }
    
        public async void WriteData(string data)
        {
    
            StorageFile file = await KnownFolders.PicturesLibrary.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
    
            var stream = await file.OpenAsync(FileAccessMode.ReadWrite);
            
			try
			{			
				using (var outputStream = stream.GetOutputStreamAt(stream.Size))
				{
					using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
					{
						dataWriter.WriteString(data);
		
						await dataWriter.StoreAsync();
		
					}
					await outputStream.FlushAsync();
				}
			}
			finally
			{
				stream.Dispose();
			}
        }
    
    }
