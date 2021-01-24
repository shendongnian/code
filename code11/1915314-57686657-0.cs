        public class ModelProfile: Profile
        {
            public ModelProfile()
            {
                CreateMap<HomaEntity, HomeViewModel>()
                    .ForMember(dest => dest.HumansCount, opt => opt.MapFrom(src => src.Humans.Count));           
            }
        }
