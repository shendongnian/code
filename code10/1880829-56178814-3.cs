	var root = new VideoGames
	{
		Types = new []
		{
			new GameType
			{
				Name = "RPG",
				Code = new []
				{
					new Code { Text = "TestingData" },
				}
			},
		},
		Platform = new Platform  { Compressed = 3.2876m, },
	};
	
	var xml = root.GetXml(omitStandardNamespaces: true);
	Console.WriteLine(xml);
