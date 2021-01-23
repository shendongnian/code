    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new SoftwarePackages
            {
                Items = new SelectList(new[]
                {
                    new SelectListItem { Value = "1", Text = "item 1" },
                    new SelectListItem { Value = "2", Text = "item 2" },
                    new SelectListItem { Value = "3", Text = "item 3" },
                }, "Value", "Text")
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(SoftwarePackages softwarePackages)
        {
            // do something with softwarePackages.PermissionsList
            ...
        }
    }
