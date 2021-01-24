    public class MongoProvider : IMongoProvider
    {
    	#region Private Fields
    
    	private readonly IMongoClient _client;
    
    	#endregion
    
    
    	#region Constructor
    
    	...
    
    	#endregion
    
    	#region Private Methods
    
    	private void Initialize(string database, string collection)
    	{
    		var db = _client.GetDatabase(database);
    		if (!db.ListCollectionNames().ToList().Any(name => name.Equals(collection)))
    			db.CreateCollection(collection);
    	}
    
    	private async Task InitializeIndex<T>(string database, string collection) where T : new()
    	{
    		if(new T().TryCallMethod<IEnumerable<CreateIndexModel<T>>>("GetIndexModel", out var models, new IndexKeysDefinitionBuilder<T>()))
    			await _client.GetDatabase(database)
    				.GetCollection<T>(collection)
    				.Indexes
    				.CreateManyAsync(models);
    	}
    
    	private static void ValidateOptions<T>(ref FindOptions<T, T> options)
    	{
    		if(options != null)
    			return;
    
    		options = new FindOptions<T, T>
    		{
    			AllowPartialResults = null,
    			BatchSize = null,
    			Collation = null,
    			Comment = "AspNetWebService",
    			CursorType = CursorType.NonTailable,
    			MaxAwaitTime = TimeSpan.FromSeconds(10),
    			MaxTime = TimeSpan.FromSeconds(10),
    			Modifiers = null,
    			NoCursorTimeout = false,
    			OplogReplay = null
    		};
    	}
    
    	private static FilterDefinition<T> GetFilterDefinition<T>(Func<FilterDefinitionBuilder<T>, FilterDefinition<T>>[] builders)
    	{
    		if(builders.Length == 0)
    			builders = new Func<FilterDefinitionBuilder<T>, FilterDefinition<T>>[] {b => b.Empty};
    
    		return new FilterDefinitionBuilder<T>()
    			.And(builders
    				.Select(b => b(new FilterDefinitionBuilder<T>()))
    			);
    	}
    
    	#endregion
    
    	#region Public Methods
    
    	public async Task<IReadOnlyCollection<T>> SelectManyAsync<T>(string database, string collection, FindOptions<T, T> options = null, params Func<FilterDefinitionBuilder<T>, FilterDefinition<T>>[] builders) where T : new()
    	{
    		ValidateOptions(ref options);
    		await InitializeIndex<T>(database, collection);
    		var filter = GetFilterDefinition(builders);
    
    		var find = await _client.GetDatabase(database)
    			.GetCollection<T>(collection)
    			.FindAsync(filter, options);
    
    		return await find.ToListAsync();
    	}
    	
    	...
    
    	#endregion
    }
