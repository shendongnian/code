    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveProfileResource, Profile>()
                .ForMember(src => src.Gender,
                           opt => opt.MapFrom(src => Enum.Parse(typeof(EGender), src.Gender)));
        }
    }
