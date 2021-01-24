lang-csharp
public class DemonstrationController
{
	private readonly IRepositoryFactory _storeEntitiesRepoFactory;
	public DemonstrationController(IRepositoryFactory storeEntitiesRepoFactory)
	{
		_storeEntitiesRepoFactory = storeEntitiesRepoFactory;
	}
	[HttpGet]
	public IHttpActionResult Get()
	{
		var empRepo1 = _storeEntitiesRepoFactory.GetRepository("DB1");
		var empRepo2 = _storeEntitiesRepoFactory.GetRepository("DB2");
		
		// After the second line, empRepo1 is connected to "DB2" since both repositories are referencing the same
		// instance of StoreEntities
	}
}
If you changed `StoreEntitiesFactory` to return the same repository based on the given parameter, this would solve that problem.
lang-csharp
public class StoreEntitiesFactory : IRepositoryFactory
{
	private bool _disposed;
	private Dictionary<string, StoreEntities> _contextLookup;
	public StoreEntitiesFactory()
	{
		_contextLookup = new Dictionary<string, StoreEntities>();
	}
	public IGenericRepository<TDbSet> GetRepository<TDbSet>(string dbName) where TDbSet : class
	{
		if (!_contextLookup.TryGetValue(dbName, out StoreEntities context))
		{
			context = new StoreEntities();
			// You would set up the database here instead of in the Repository, and you could eliminate
			// the ChangeDatabase function.
			
			_contextLookup.Add(dbName, context);
		}
		return new GenericRepository<TDbSet, StoreEntities>(context);
	}
	
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize();
	}
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			if (disposing)
			{
				foreach (var context in _contextLookup.Values)
				{
					context.Dispose();
				}
			}
			_disposed = true;
		}
	}
}
As for the second question, you would need the dispose logic in the factory since it owns the instances of `StoreEntities` being created. No need to use `using` statements around the repositories it creates, just let Unity dispose of the factory.
