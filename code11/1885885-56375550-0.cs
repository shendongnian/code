    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _work;
        private readonly IMapper _mapper;
        public DepartmentController(IUnitOfWork work, IMapper mapper)
        {
            _work = work;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(DepartmentViewModel viewmodel)
        {
            var lstAllDepartments = _work.DepartmentRepository.GetAll(); // All departments from the database.
            var lstDepartmentsForViewmodel = _mapper.Map<IEnumerable<Core.Entities.Department>, IEnumerable<DepartmentDto>>(lstAllDepartments); // Map to DTO.
            viewmodel.lstDepartments = lstDepartmentsForViewmodel;
            return View(viewmodel);
        }
    }
