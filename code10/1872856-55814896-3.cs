    public class AppMappingProfile : Profile
    {
    public AppMappingProfile()
    {
    CreateMap<Card, CardViewModel>()
       .ForMember(d => d.PropVM1, ex => ex.MapFrom(o => o.Prop1))
       .ForMember(d => d.PropVM2, ex => ex.MapFrom(o => o.Prop2))
       .ForMember(d => d.PropVM3, ex => ex.MapFrom(o => o.Prop3))
       .ReverseMap() // if a two-away Mapping is necessary
    }
    } 
