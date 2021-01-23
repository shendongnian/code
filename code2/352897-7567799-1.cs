    class Countries
    {
       List<Country> countries = new List<Country>();
    
       public void Add(Country c)
       {
          countries.Add(c);
       }
    
       public List<Country> getByShortName();
       public List<Country>  getById();
       public List<Country>  getAll();
    }
