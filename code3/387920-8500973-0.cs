        public ActionResult Detail(object id)
        {
            int myID;
            if (int.TryParse(id.ToString(), out myID))
            {
                ViewData["value"] = _discipline.GetValueById(id);
                return View();
            }
        }
