        [HttpPost]
        public ActionResult Display(FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                string month = collection["Month"];
                string extra = collection["Extra"];
                return RedirectToAction("Index");
            }
            return View();
        }
