       [HttpGet]
       public ActionResult Jobs(string name)
       {
          var allDetails = _db.MyDB.Where(p => p.name == name).FirstOrDefault();
          return View(allDetails);
       }
