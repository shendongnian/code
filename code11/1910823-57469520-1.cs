    namespace API_MVC
    {
        public class AutoMapperConfigurationApi : Profile
        {
            protected override void Configure()
            {
                CreateMap<EnquiryCreateRequest, EnquiryDto>();
                
            }
        }
    }
