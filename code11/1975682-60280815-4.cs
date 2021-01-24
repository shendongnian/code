    public class EmployeesModel : PageModel
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public List<Employee> EmployeeList; // <-- Here is the EmployeeList property
        public async Task OnGetAsync()
        {
            EmployeeList = await _employeeService.GetEmployees(); // <-- Populate EmployeeList here
        }
    }
