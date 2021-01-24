    namespace ContosoUniversity.Controllers
    {
        public class TimeSheetController : Controller
        {
            private readonly TimeSheetContext _context;
    
            public TimeSheetController(TimeSheetContext context)
            {
                _context = context;
            }
        }
    }
