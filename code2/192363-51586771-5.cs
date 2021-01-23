    public ActionResult YourTestMethod()
    {
        var linqResults = (from e in db.YourTable
                           select e.Total);
        if (linqResults != null)
        {
            return Json(linqResults.ToList().Sum(), JsonRequestBehavior.AllowGet);
        }
        else
        {
            return Json(0, JsonRequestBehavior.AllowGet);
        }
    }
