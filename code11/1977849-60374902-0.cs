    class YourObjectProfile : Profile
        {
            public YourObjectProfile()
            {
                CreateMap<UI_Object, Domain_Object>()
                    .ForMember(c => c.name, p => p.MapFrom(dbc => dbc.name));
    
                CreateMap<Domain_Object, UI_Object>()
                    .ForMember(dbc => dbc.name, dbp => dbp.MapFrom(c => c.name));
            }   
        }
