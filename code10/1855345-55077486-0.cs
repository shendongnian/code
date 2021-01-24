     public class PersonController : Controller
        {
        
            public ActionResult Index()
            {
                return this.View();
            }
    
            public JsonResult OnGetList()
            {
                List<Person> list = new List<Person>();
    
          
                foreach (var item in _context.Person.ToList())
                {
                    list.Add(item);
                }
    
                return Json(list, JsonRequestBehavior.AllowGet);
            }
    }
