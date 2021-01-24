    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<A, ADto>();
            CreateMap<B, BDto>();
            CreateMap<C, CDto>();
        }
    }
