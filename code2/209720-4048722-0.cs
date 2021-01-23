    public class Country : IEnumerable<Element>
    {
       public string Name { get {...} }       
       public int Population { get { return this.Sum(e => e.Population); } }
       ...
    }
    public class World : IEnumerable<Country>
    {
      ...
    }
