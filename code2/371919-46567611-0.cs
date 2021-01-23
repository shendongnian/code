    using AutoMapper;
    
    namespace Your.Namespace
    {
        public class MappingProfile : Profile
        {
            MappingProfile()
            {
                CreateMap<Animal, AnimalDto>();
            }
        }
    }
