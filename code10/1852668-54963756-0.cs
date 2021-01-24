    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            .CreateMap<Tradeline, TRADELINE>()       
             .ForPath(dest => dest.TLSOURCE, opt => opt.MapFrom(src => src.Source))                       
    		 .ForMember(dest => dest.REQID, opt => opt.MapFrom((src, dest, destMember, context) => context.Items["REQID"]))
        }
    }
