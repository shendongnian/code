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
				await stream.FlushAsync(); // not possible to discard
				await writer.FlushAsync();
				
				await writer.DisposeAsync(); // use DisposeAsync instead of Close to not block
				
				if (File.Exists(filePath))
					File.Delete(filePath);
				throw new OperationCanceledException();
			}
			// write to the stream
			await writer.WriteLineAsync(line.ToString());
		}
		await writer.FlushAsync();
		await stream.FlushAsync();
		
		return null;
	}
