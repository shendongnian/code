    Mapper.CreateMap<Foo, FooViewModel>()
    .AfterMap(MapAlphaBetaFromFooToFooViewModel);
    
    
    public void MapAlphaBetaFromFooToFooViewModel(Foo foo, FooViewModel fooViewModel)
    {
    // Here the code for loading and mapping you objects
    }
