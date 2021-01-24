	private async Task Generate(int projectId, DateTime period, Action<FileStream> operation)
	{
		using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
		{
			operation(fs);
		}
	}
