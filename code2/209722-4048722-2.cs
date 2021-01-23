    public interface IGeographicEnity
    {
       string Name { get; }
       int Population { get; }
    }
    public class City : IGeographicEntity {...}
    public class Country : IGeographicEntity
    {
       public IList<City> Cities { get {...} }       
       public int Population { get { return Cities.Sum(c => c.Population); } }
       ...
    }
    public class World : IGeographicEntity
    {
        public IList<Country> Countries{ get {...} }       
        public int Population { get { return Countries.Sum(c => c.Population); }
        ...
    }
