    public class EmployeesModel : PageModel
    {
        private readonly EmployeeService _employeeService;
        public EmployeesModel(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public List<Employee> EmployeeList; // <-- Here is the EmployeeList property
        public void OnGet()
        {
            EmployeeList = _employeeService.GetEmployees(); // <-- Populate EmployeeList here
        }
    }
