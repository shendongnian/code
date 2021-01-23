    public class Bar()
    {
        public Bar()
        {
            Id = Guid.NewGuid();
        }
    
        public Guid Id { get; set; }
        public string Name { get; set; }
        [IgnoreDataMember]
        public virtual Foo Foo { get; set;}
    }
