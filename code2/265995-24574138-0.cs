    public async Task DoFoo()
		{
			try
			{
				return await Foo();
			}
			catch (ProtocolException ex)
			{
				/* Exception with chronological stack trace */     
			}
		}
