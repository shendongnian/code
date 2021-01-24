    public class CompanyToCompanyDtoResolver : IValueResolver<Company, CompanyDto, List<AddressDto>>
    {            
        public List<AddressDto> Resolve(Company source, CompanyDto destination, List<AddressDto> destMember, ResolutionContext context)
        {
            var contacts = new List<AddressDto>();
            var companyType = typeof(Company);
            for (int i = 1; i <= 6; i++)
            {
                var address = new AddressDto();
                address.CONTACT_ADDR1 = (string)companyType
                    .GetProperty(nameof(Company.CONTACT_ADDR1_1).Replace("_1", $"_{i}"))
                    .GetValue(source);
                address.CONTACT_ADDR2 = (string)companyType
                    .GetProperty(nameof(Company.CONTACT_ADDR2_1).Replace("_1", $"_{i}"))
                    .GetValue(source);
                address.CONTACT_CITY = (string)companyType
                    .GetProperty(nameof(Company.CONTACT_CITY_1).Replace("_1", $"_{i}"))
                    .GetValue(source);
                address.CONTACT_STATE = (string)companyType
                    .GetProperty(nameof(Company.CONTACT_STATE_1).Replace("_1", $"_{i}"))
                    .GetValue(source);
                address.CONTACT_ZIP = (string)companyType
                    .GetProperty(nameof(Company.CONTACT_ZIP_1).Replace("_1", $"_{i}"))
                    .GetValue(source);
                contacts.Add(address);
            }
            return contacts;
        }
    }
    ...
        cfg.CreateMap<Company, CompanyDto>()
           .ForMember(destination => destination.Contacts, 
                      source => source.MapFrom<CompanyToCompanyDtoResolver>());
