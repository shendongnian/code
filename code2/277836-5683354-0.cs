    public FooMap : ClassMap<Foo> 
    {
       public FooMap()
       {
          Id(x => x.Id);
          HasMany(x => x.Components).KeyColumn("SourceID").Cascade.All();
       }
    }
