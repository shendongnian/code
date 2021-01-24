	public ImmutableTestMap()
	{
		AutoMap();
		
		Map(immutableTest => immutableTest.Id)
			.Index(0)
			.Name(nameof(ImmutableTest.Id).ToUpper());
	}
