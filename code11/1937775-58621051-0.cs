    public class Default16Controller : Controller
    {
        // GET: Default16
        public ActionResult Index()
        {
            List<SelectListItem> li = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Select",
                    Value = ""
                    
                },
                new SelectListItem()
                {
                    Text = "One",
                    Value = "1",
                    Selected = true // Setting Item as Selected
                },
                new SelectListItem()
                {
                    Text = "Two",
                    Value = "2"
                }
            };
            ViewBag.LoadType = li;
            return View();
        }
    }
