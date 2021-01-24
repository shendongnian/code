    await writer.DisposeAsync();
---
	public async Task<IErrorResult> WriteToFileAsync(string filePath,
													 CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await using var stream = new FileStream(filePath, FileMode.Create);
		await using var writer = new StreamWriter(stream, Encoding.UTF8);
		foreach (var line in Lines)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				// not possible to discard, FlushAsync is covered in DisposeAsync
				await writer.DisposeAsync(); // use DisposeAsync instead of Close to not block
				
				if (File.Exists(filePath))
					File.Delete(filePath);
				throw new OperationCanceledException();
			}
			// write to the stream
			await writer.WriteLineAsync(line.ToString());
		}
		// FlushAsync is covered in DisposeAsync
		return null;
	}
