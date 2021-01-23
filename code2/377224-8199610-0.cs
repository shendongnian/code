    public class City
    {
       public string Name {get;set;}
       public string Country {get;set;}
    }
    
    ...
    
    public List<City> GetCities()
    {
       List<City> cities = new List<City>();
       cities.Add(new City() { Name = "Istanbul", Country = "Turkey" });
       return cities;
    }
