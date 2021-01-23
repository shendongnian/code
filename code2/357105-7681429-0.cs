    public class Foo
    {
        public int FooId { get; set; }
        public string SomeProperty { get; set; }
    
        public virtual IEnumerable<Bar> Bars { get; set; }
    }
