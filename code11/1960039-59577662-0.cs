         public ActionResult Home()
        {
            List<string> names = new List<string>();
            names.Add("Foo");
            names.Add("Bar");
            return View(names);
        }
