    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Operator, OperatorDto>().ReverseMap();
        }
    }
