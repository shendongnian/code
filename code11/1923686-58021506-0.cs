    [Route("api/[controller]")]
    [ApiController]
    public class AllItProjectsListsController : ControllerBase
    {
        private readonly KPIContext _context;
        private readonly IProject objProject;
        public AllItProjectsListsController(IProject _objProject)
        {
            objProject = _objProject;
        }
        [HttpGet("Index")]
        public IEnumerable<AllItProjectsList> Index()
        {
            return objProject.GetAllProjectDetails();
        }
    }
