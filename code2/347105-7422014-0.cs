	private void WriteFileSynchronous(string FileName, MemoryStream Data)
	{
		Task.Factory.StartNew(() => WriteFileSynchronously(FileName, Data));
	}
	
	private void WriteFileSynchronous(string FileName, MemoryStream Data)
	{
		try
		{
			using (FileStream DiskFile = File.OpenWrite(FileName))
			{
				Data.WriteTo(DiskFile);
				DiskFile.Flush();
				DiskFile.Close();
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
