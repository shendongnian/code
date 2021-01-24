    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MyModel, MyModelDto>();
        }
    }
