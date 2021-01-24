    public class Common
    {
        // This property is valid for Foo AND Bar
        public int Property1 { get; set; }
    }
    public class Foo : Common
    {
        // This property is valid for Foo ONLY.
        public string Property2 { get; set; }
    }
    public class Bar : Common
    {
        // This cannot and *hence will not* exist in Bar.
        // public new string Property2;
        // This property is valid for Bar ONLY.
        public List<int> Property3 { get; set; }
    }
