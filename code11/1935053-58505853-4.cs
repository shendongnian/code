    public class BaseMappingProfile : Profile
    {
        public BaseMappingProfile(IDateTime datetime)
        {
            this.CreateMap<Foo, FooDto>()
                .ForMember(d => d.Timestamp, o => o.MapFrom(s => datetime))
                .ForMember(d => d.PropertyA, o => o.MapFrom(s => s.Property1));
        }
    }
    
    public class FooMappingProfile : Profile
    {
        public FooMappingProfile()
        {
            this.CreateMap<FooDerived, FooDerivedDto>()
                .IncludeBase<Foo, FooDto>()
                .ForMember(d => d.PropertyB, o => o.MapFrom(s => s.Property2));
        }
    }
