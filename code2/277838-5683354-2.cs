    public FooMap : ClassMap<Foo> 
    {
       public FooMap()
       {
          Id(x => x.ID, "SourceID");
          HasMany(x => x.Components)
             .KeyColumn("SourceID")
             .Inverse()
             .Cascade.All();
       }
    }
