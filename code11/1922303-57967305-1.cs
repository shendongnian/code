    public static async Task IgnoreException(this Task task)
	{
		try
		{
			await task;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error: {ex.Message}");
		}
	}
