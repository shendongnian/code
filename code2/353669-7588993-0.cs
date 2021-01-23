    public class ModelMapper
    {
        static ModelMapper()
        {
            Mapper.CreateMap<FooView,Foo>()
                  .ForMember( f => f.Bars, opt => opt.Ignore() );
            Mapper.AssertConfigurationIsValid();
        }
        public Foo CreateFromModel( FooView model, IEnumerable<Bar> bars )
        {
             var foo = Mapper.Map<FooView,Foo>();
             foreach (var barId in model.BarIds)
             {
                 foo.Bars.Add( bars.Single( b => b.Id == barId ) );
             }
             return foo;
        }
    }
