    public class FromModelToDto : Profile
    {
    	public FromModelToDto ()
    	{
    		CreateMap<CompanyEmployee, EmployeeDto>();
    	}
    }
