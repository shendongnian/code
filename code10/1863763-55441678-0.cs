    namespace WebApplication2.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                ViewBag.Title = "Home Page";
                var studentList = new List<SelectListItem>()
                {
                    new SelectListItem {Text = "ABC", Value = "1"},
                    new SelectListItem {Text = "CDE", Value = "2"},
                };
                ViewData["studentList"] = studentList;
                return View();
            }
    
            public ActionResult Student()
            {
                var studentList = new List<SelectListItem>()
                {
                    new SelectListItem {Text = "Peter Cech", Value = "S001"},
                    new SelectListItem {Text = "Leo Messi", Value = "S002"},
                };
                ViewData["studentList"] = studentList;
                AppointmentViewModel model = new AppointmentViewModel();
                model.FK_StudentId = "S001";
    
                return View(model);
            }
        }
    
        public class AppointmentViewModel
        {
            public string FK_StudentId { get; set; }
        }
    }
