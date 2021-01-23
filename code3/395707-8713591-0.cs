    public class Country
    {
    	private List<City> _cities;
    
    	public int Id { get;set; }
    	public IEnumerable<City> Cities
    	{
    		get
    		{
    			// load on demand
    			if (_cities == null)
    				_cities = LoadCities(Id);
    				
    			return _cities;
    		}
    	}
    }
    
    public class City
    {
    	public int Id { get;set; }
    	public Country Country { get;set; } 
    }
