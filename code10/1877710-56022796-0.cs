	public async Task<IEnumerable<string>> GetListDriversAsync()
	{
		var drives = await graphClient.Drive.Root.Children.Request().GetAsync();
	
		IEnumerable<string> GetListDrivers()
		{
			foreach (var d in drives)
				yield return d.ToString();
		}
		
		return GetListDrivers();
	}
