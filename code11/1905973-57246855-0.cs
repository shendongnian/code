    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountModel, ApplicationUser>();
        }
    }
