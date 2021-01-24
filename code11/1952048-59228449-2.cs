    [HttpPost]
    public ActionResult MapService(LocationInfo data)
    {
        CrisisSite CrisisSite = new CrisisSite();
        if (ModelState.IsValid)
        {
                var crisisId = db.CrisisSite.ToList().Max().Id;
                crisisId = crisisId + 1;
                CrisisSite.Site = data.Site;
                CrisisSite.Latitude = Convert.ToDecimal(data.Latitude);
                CrisisSite.Longitude = Convert.ToDecimal(data.Longitude);
                db.CrisisSite.Add(CrisisSite);
                db.SaveChanges();
        }
        return Json(CrisisSite,JsonRequestBehavior.AllowGet);
        //return View();
    } 
