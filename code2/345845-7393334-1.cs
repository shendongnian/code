    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel
            {
                DaysOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.DayNames.Select(x => new DayOfWeekViewModel
                {
                    DayOfWeek = x,
                })
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            // model.DaysOfWeek will contain all you need here
            // TODO: do some processing
            // here you can loop through model.DaysOfWeek to identify which 
            // days have been selected and take respective actions
            // ...
            // once you have finished processing you could redirect
            return RedirectToAction("success");
        }
    }
