    Mapper
        .CreateMap<int, Category>()
        .ForMember(
            dest => dest.ID, 
            opt => opt.MapFrom(src => src)
    );
    Mapper
        .CreateMap<GatewayViewModel, Gateway>()
        .ForMember(
            dest => dest.Categories, 
            opt => opt.MapFrom(src => src.CategoryID)
    );
    var source = new GatewayViewModel
    {
        CategoryID = new[] { 1, 2, 3 }
    };
    Gateway dst = Mapper.Map<GatewayViewModel, Gateway>(source);
