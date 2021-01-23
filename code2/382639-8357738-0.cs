        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            List<string> items = new List<string>();
            items.Add("Product1");
            items.Add("Product2");
            items.Add("Product3");
            ViewBag.Items = items;
            return View();
        }
