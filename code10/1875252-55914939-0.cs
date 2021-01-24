    var client = new ElasticClient();
	
	var createIndexResponse = client.CreateIndex(defaultIndex, c => c
		.Mappings(m => m
			.Map<DummyRecord>(mm => mm
				.AutoMap()
			)
		)
	);
	
	if (!createIndexResponse.IsValid) {
		Console.WriteLine(createIndexResponse.DebugInformation);
	}
