    [DataContract(IsReference=true)]
    public class Foo()
    {
        public Foo()
        {
            Id = Guid.NewGuid();
            Bars = new Collection<Bar>();
        }
    
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public virtual ICollection Bars { get; set; }
    }
    
    [DataContract(IsReference=true)]
    public class Bar()
    {
        public Bar()
        {
            Id = Guid.NewGuid();
        }
    
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public virtual Foo Foo { get; set;}
    }
