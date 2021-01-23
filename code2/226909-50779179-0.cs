    private void CreateIndex()
    {
    	var indexOptions = new CreateIndexOptions {Collation = _caseInsensitiveCollation};
    	var indexDefinition
    		= Builders<MyDto>.IndexKeys.Combine(
    			Builders<MyDto>.IndexKeys.Ascending(x => x.Foo),
    			Builders<MyDto>.IndexKeys.Ascending(x => x.Bar));
    	_myCollection.Indexes.CreateOne(indexDefinition, indexOptions);
    }
