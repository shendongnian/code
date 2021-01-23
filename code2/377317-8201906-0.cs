    public class Foo
    {
        public int FooId { get; set; }
        public string SomeValue { get; set; }
        public virtual ICollection<FooBar> FooBars { get; set; } 
    }
