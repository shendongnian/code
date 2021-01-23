    public class HomeController : Controller
    {
        public ActionResult HandleForm(string favColor, string otherColorText)
        {
            // Add action logic here
            // If you want to have a separated field for your database,
            // just do something like that:
            MyDbFacade.BlueColorField = (favColor == "Blue");
            MyDbFacade.GreenColorField = (favColor == "Green");
            ...
            return View();
        }
    }
