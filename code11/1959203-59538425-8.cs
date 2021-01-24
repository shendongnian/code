    public class Foo
    {
        public virtual ICollection<Bar> Bars { get; set; }
    }
    public class Bar
    {
        public virtual ICollection<Foo> Foos { get; set; }
    }
