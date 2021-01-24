    public class YourCustomProfile : Profile
        {
              public GamingStandaloneProfile()
              {
                   AllowNullCollections = true;
                   AllowNullDestinationValues = true;
    
                   CreateMap< ConfigurationSetting, ConfigurationSettingDTO>()
                        .ForMember(d => d.Key, opt => opt.MapFrom< ConfigurationSettingKeyResolver >());
              }
        }
