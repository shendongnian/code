        public class MapperProfiles : Profile
        {
            public MapperProfiles()
            {
                CreateMap<YourModel, YourViewModel>();
                CreateMap<YourViewModel, YourModel>();
            }
        }
