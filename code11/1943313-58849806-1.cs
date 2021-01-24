    //[Route("api/[controller]")]
    //[ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly WSDbContext _context;
        public StudentsController(WSDbContext context)
        {
            _context = context;
        }
        // GET: api/Students
        [HttpGet]
        [EnableQuery()]
        public IEnumerable<Student> Get()
        {
            return _context.Students;
        }
    }
    //[Route("api/[controller]")]
    //[ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly WSDbContext _context;
        public SchoolsController(WSDbContext context)
        {
            _context = context;
        }
        // GET: api/Schools
        [HttpGet]
        [EnableQuery()]
        public IEnumerable<School> Get()
        {
            return _context.Schools;
        }
