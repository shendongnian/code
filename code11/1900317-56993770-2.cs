	public ImmutableTestMap()
	{
		AutoMap();
		Map(immutableTest => immutableTest.Id)
			.Index(0)
			.Name(nameof(ImmutableTest.Id).ToUpper());
		Map(immutableTest => immutableTest.Name)
			.Index(0)
			.Name(nameof(ImmutableTest.Id));
		if (MemberMaps.Count != ParameterMaps.Count)
		{
			return;
		}
		for (int i = 0; i < MemberMaps.Count; i++)
		{
			ParameterMaps[i].Data.Name = MemberMaps[i].Data.Names[0];
		}
	}
