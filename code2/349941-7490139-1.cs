    public abstract class NamedItem { public abstract string Name { get; } }
    struct Thing { public string Name { get; set; } }
    
    var namedItems1 = new NamedItemCollection<NamedItem>();
    var namedItems2 = new NamedItemCollection<Thing>();
    var namedItems3 = new NamedItemCollection<Type>();
