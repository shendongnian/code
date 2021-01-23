            [HttpGet]
        public ActionResult Comment(string ID)
        {
            int id = Convert.ToInt32(ID);
            if (ID != null)
            {
                try
                {
                    var model = from r in _db.Gallery
                                where r.ID == id
                                select r;
                    
                    return View(model);
                }
                catch
                {
                }
            }
            return View();
        }
