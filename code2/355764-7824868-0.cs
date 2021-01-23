    public class Country
    {
        public Country(string name)
        {
            this.Name = name;
            
        }
        
        // for NHibernate
        protected Country()
        {
            this.Cities = new List<City>();
        }
    
        public virtual int Id { get; private set; }
        public virtual string Name { get; private set; }
        public virtual IList<City> Cities { get; private set; }
    
        public virtual City AddCity(string name)
        { 
            var city = new City(this, name);
            this.Cities.Add(city);
            return city;
        }
    }
    
    public class City
    {
        public City(Country country, string name)
        {
            this.Country = country;
            this.Name = name;
        }
    
        // for NHibernate
        protected City()
        {
        }
        public virtual int Id { get; private set; }
        public virtual string Name { get; private set; }
        public virtual Country Country { get; private set; }
    }
