    public class Manufacturer : IEquatable<Manufacturer>
    {
        public string Name { get; private set; }
        public int ID { get; private set; }
        // ...
    }
    
    public class Product
    {
        public string Name { get; private set; }
        public int ID { get; private set; }
        // ...
    }
    
    // groups is of type IEnumerable<IGrouping<Manufacturer, Product>>
    
    var groups = data.GroupBy(row => new Manufacturer(row), row => new Product(row));
