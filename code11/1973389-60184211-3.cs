    public class FromDtoToModel : Profile
    {
    	public FromDtoToModel ()
    	{
    		CreateMap<EmployeeDto, CompanyEmployee>()
                .ForMember(dest.EmployeeId, opts => opts.MapFrom(model => model.Id))
    	}
    }
