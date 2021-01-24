    public class HomeController : Controller
    {
        public static readonly string viewNameWithGrid = "Grid";
        public static readonly int defaultPageSize = 10;
    
        private static readonly string SavedPageSizeSessionKey = "PageSizeKey";
        public int SavedPageSize
        {
            get
            {
                if (Session[SavedPageSizeSessionKey] == null)
                    Session[SavedPageSizeSessionKey] = defaultPageSize;
                return (int)Session[SavedPageSizeSessionKey];
            }
            set { Session[SavedPageSizeSessionKey] = value; }
        }
    
        //The same as the Action name
        //return View(result);
        //Initial Load
        [HttpGet]
        public ActionResult Grid()
        {
            return GetViewWithGrid(SavedPageSize);
        }
    
        //Change Page Size
        [HttpPost]
        public ActionResult Grid(int? Page)
        {
            if (Page.HasValue)
                SavedPageSize = Page.Value;
            //Page = DropDownList.id
            return GetViewWithGrid(SavedPageSize);
        }
    
        ActionResult GetViewWithGrid(int pageSize)
        {
            schoolEntities db = new schoolEntities();
            List<Student> result = db.Students.ToList();
    
            //ViewBag.pageSize = int.Parse(pagesizelist.SelectedValue);
            ViewBag.pageSize = pageSize;
            return View(viewNameWithGrid, result);
        }
    }
