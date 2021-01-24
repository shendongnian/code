    public interface IEmployeeService : IApplicationService
    {
        int CreateEmployee(CreateEmployeeDto data);
        IEnumerable<EmployeeListDto> GetEmployeeList();
    }
