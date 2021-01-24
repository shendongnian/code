     public ActionResult Index()
        {
            string firstnamevalue = "Hello";
            string lastnamevalue = "Welcome";
            List<string> list = new List<string>();
            list.Add(firstnamevalue);
            list.Add(lastnamevalue);
            TempData["plist"] = list;
            ViewBag.s = TempData["plist"];
            return View("Index");
        }
