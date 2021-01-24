        public class MapperProfile: Profile
        {
           public MapperProfile()
          {
            CreateMap<ChannelTypeT, ChannelTypeTDto>().ReverseMap();
            CreateMap<ChannelType, ChannelTypeDtoIncluding>()
                .ForMember(d => d.Text, opt => opt.MapFrom(s => s.ChannelTypeT.Text))
                .ReverseMap();
          }
        }
