    [WebMethod]
    public void AddCity(string countryCode, string name)
    {
        ICountryDataAccess dao = GetDAOFromDI(); // basically get a DI framework to manage this object instance.
        dao.AddCity(countryCode, name);
    }
    
    public interface ICountryDataAccess 
    {
        void AddCity(string countryCode, string name);
        ICollection<City> GetAllCities(string countryCode);
        // OR !
        Country Retrieve(string countryCode);
        // using an ORM or something Country then as a list of cities
    }
    
    public Country 
    {
        public virtual string CountryCode {get;set;} 
        public virtual ICollection<City> Cities {get; protected set;}
    }
