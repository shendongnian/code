    public class MyClassController : Controller
    {
        private ProjectContext db = new ProjectContext();
        //
        // GET: /MyClass/
        public ViewResult Index()
        {
            return View(db.MyClasses.ToList());
        }
    }
