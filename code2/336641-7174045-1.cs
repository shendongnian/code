    class SecondMap : ClassMap<Second>
    {
        public SecondMap()
        {
            CompositeId()
                .KeyReference(f => f.First, "Id");
            Map(s => s.Number);
        }
    }
    class Second
    {
        public virtual First First {get; set;}
        public virtual int Number { get; set; }
        // required for Compositekeys
        public override bool Equals(object obj)
        {
            var other = obj as Second;
            return (other != null) && (First.Id == other.First.Id) ;
        }
        // required for Compositekeys
        public override int GetHashCode()
        {
            return First.Id.GetHashCode();
        }
    }
