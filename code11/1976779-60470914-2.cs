    public enum Localized
    {
    	English,
    	Arabic,
    	French
    }
    
    public class PlaceRepo : IDisposable
    {
    	private readonly PlacesEntityModel _context = new PlacesEntityModel();
    	
    	public List<Place> GetPlacesLocalized(Localized localized = Localized.English)
    	{
    		string local = localized == Localized.Arabic ? "$.ar"
    					: localized == Localized.French ? "$.fr"
    					: "$.en";
    	
    		return _context.Places.SqlQuery("SELECT Id, name-> @p0 as Name FROM places", new[] { local })
    			.Select(x=> new Place { Id = x.Id, Name = x.Name.Replace("\"", string.Empty).Trim() })
    			.ToList();
    	}
    
    
    	private bool _disposed = false;
    	public void Dispose()
    	{
    		Dispose(true);
    		GC.SuppressFinalize(this);
    	}
    
    	protected virtual void Dispose(bool disposing)
    	{
    		if (!_disposed)
    		{
    			if (disposing)
    			{
    				_context.Dispose();
    			}
    			_disposed = true;
    		}
    	}
    
    	~PlaceRepo()
    	{
    		Dispose(false);
    	}
    }
