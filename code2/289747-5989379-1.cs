        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Show(int? id)
        {
            var showViewModel = new ShowViewModel();
            // ... populate ViewModel
            return View(showViewModel);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Modify(FormCollection form)
        {
            var id = form["id"];
            var p1 = form["p1"];
            var p2 = form["p2"];
            // ... Modify
            return RedirectToAction("Show", new { id = id });
        }
