    public class StudentsController : Controller
    {
        private void _SetViewData()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Child", Value = "0" });
            items.Add(new SelectListItem { Text = "Teen", Value = "1" });
            items.Add(new SelectListItem { Text = "Adult", Value = "2" });
            items.Add(new SelectListItem { Text = "Other", Value = "3" });
            items.Add(new SelectListItem { Text = "check", Value = "4" });
            ViewData["MembershipID"] = items;
        }
        // GET: Students
        public ActionResult Index()
        {
            return View();
        }
        // GET: Students/Create
        public ActionResult Create()
        {
            _SetViewData();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            { 
                // TODO: Add insert logic here 
                using (BlackBeardDBEntities db = new BlackBeardDBEntities()) 
                { 
                    db.Students.Add(student); db.SaveChanges(); 
                }                 
                return RedirectToAction("Index"); 
            } 
            catch {
                // Either you can redirect to the action which will reload the viewdata
                // return RedirectToAction("Create");
                // OR you could load the viewdata and use the same view
                _SetViewData();
                return View();
            } 
        } 
    }
