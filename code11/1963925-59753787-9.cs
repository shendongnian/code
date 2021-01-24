    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
     
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Insert()
        {
            Employee employee = new Employee();
            await _unitOfWork.Repository<Employee>().InsertEntityAsync(employee);
            await _unitOfWork.SaveChangesAsync();
            return View();
        }
    }
