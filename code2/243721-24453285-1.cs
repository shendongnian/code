    namespace MvcVariousApplication.Controllers
        {
            public class HomeController : Controller
            {
                public ActionResult Index()
                {
                  RechargeMobileViewModel objModel = new RechargeMobileViewModel();
                    objModel.getAllDaysList = objModel.getAllWeekDaysList();  
                    return View(objModel);
                }
        }
        }
