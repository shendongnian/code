    class controller
    {
        public ActionResult Index()
        {
           var dtos = get data from database();
           return View(dtos);
        }
    }
