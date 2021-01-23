    public class City
    {
    	public City(string name, string country)
    	{
    		Name = name;
    		Country = country;
    	}
    
    	public string Name { get; private set; }
    	public string Country { get; private set; }
    }
    
    public List<City> GetCities()
    {
    	return new List<City>{
    		new City("Istanbul", "Turkey"),
    		new City("Athens", "Greece"),
    		new City("Sofia", "Bulgaria)
    	};
    }
