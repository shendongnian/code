    public class Bar
    {
        public int Id { get; set; }
        public int FooId { get; set; }
        [IgnoreDataMember]
        public Foo Foo { get; set; }
    }
