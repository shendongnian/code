        public ActionResult Delete(string nm)
        {
            if (!String.IsNullOrEmpty(nm))
            {
                ViewBag.Name = nm;
            }
            return RedirectToAction("Index");
        }
