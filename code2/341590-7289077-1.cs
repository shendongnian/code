    public class Foo
    {
        public string Name { get; set; }
        public Lookup Lookup { get; set; }
    }
    public class Lookup
    {
        public string Name { get; set; }
        public Description Description { get; set; }
    }
    public class Description
    {
        public string English { get; set; }
        public string French { get; set; }
    }
