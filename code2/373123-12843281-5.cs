    using MvcApplication1.Models;
    //...
        public ActionResult Create()
        {
            return PartialView("_Create");
        }
        [HttpPost]
        public ActionResult Create(MyViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SaveChanges(model);
                    return Json(new { success = true });
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
                
            }
            //Something bad happened
            return PartialView("_Create", model);
        }
        static void SaveChanges(MyViewModel model)
        {
            // Uncommment next line to demonstrate errors in modal
            //throw new Exception("Error test");
        }
