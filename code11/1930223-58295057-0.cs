    var client = new ElasticClient();	
	var CurrentAliasName = "alias_name";
	var CurrentIndexName = "index_name";
	
	var indexExists = client.Indices.Exists(CurrentAliasName).Exists;
	
	client.Indices.BulkAlias(aliases =>
	{
		if (indexExists)
		{
			var oldIndices = client.GetIndicesPointingToAlias(CurrentAliasName);
			var indexName = oldIndices.First().ToString();
	
			//remove alias from live index
			aliases.Remove(a => a.Alias(CurrentAliasName).Index("*"));
		}
		return aliases.Add(a => a.Alias(CurrentAliasName).Index(CurrentIndexName));
	});
