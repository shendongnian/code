    class First
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
    class Second : First
    {
        public virtual int Number { get; set; }
    }
    class FirstMap : ClassMap<First>
    {
        public FirstMap()
        {
            Id(f => f.Id).GeneratedBy.HiLo("100");
            Map(f => f.Name);
        }
    }
    class SecondMap : SubclassMap<Second>
    {
        public SecondMap()
        {
            KeyColumn("Id");
            Map(s => s.Number);
        }
    }
