    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            dynamic viewmodel = new ExpandoObject();
            viewmodel.Students = MyStudent();
            viewmodel.MenuItems = MyMenuItems();
            return View(mymodel);
        }
    }
