        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            //only selected prodcuts will be in the collection
            foreach (var product in collection)
            {
                
            }
            return View();
        }
