	public Task FillAsync()
	{
	    return Task.Factory.StartNew( () =>
		{
			adapter1.Fill(ds1);
			adapter2.Fill(ds2);
			// etc
		});
	}
