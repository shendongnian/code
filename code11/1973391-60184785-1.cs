public class EmployeeProfile : Profile
    {
        //Constructor
        public EmployeeProfile()
        {
            //Mapping properties from CompanyEmployee to EmployeeDto
            CreateMap<CompanyEmployee, EmployeeDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EmployeeId));
            //Mapping properties from EmployeeDto to CompanyEmployee 
            CreateMap<EmployeeDto, CompanyEmployee>()
            .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Id));
        }
    }
    public class CompanyProfile : Profile
    {
        //Constructor
        public CompanyProfile()
        {
            //Mapping properties from Company to CompanyDto
            CreateMap<Company, CompanyDto>()
            .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees));
            //Mapping properties from CompanyDto to Company 
            CreateMap<CompanyDto, Company>()
            .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees))
            //Setting CompanyId
            .AfterMap((src, dest) => {
                foreach (var employee in dest.Employees)
                {
                    employee.CompanyId = dest.Id;
                }
            });
        }
    }
