    public class EmployeesModel : PageModel
    {
        private readonly EmployeeService _employeeService;
        public EmployeesModel(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public List<Employee> EmployeeList; // <-- Here is the EmployeeList property
        public async Task OnGetAsync()
        {
            EmployeeList = await _employeeService.GetEmployees(); // <-- Populate EmployeeList here
        }
    }
