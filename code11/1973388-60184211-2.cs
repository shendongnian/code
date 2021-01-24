    public class FromModelToDto : Profile
    {
    	public FromModelToDto ()
    	{
    		CreateMap<CompanyEmployee, EmployeeDto>()
                .ForMember(dest.Id, opts => opts.MapFrom(model => model.EmployeeId))
    	}
    }
