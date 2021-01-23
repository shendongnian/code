     public ActionResult YourTestMethod()
            {
                var linqResults = (from e in db.YourTable
                                   select e.FieldYouWantToCount);
    
                if (linqResults != null)
                {
                    return Json(linqResults.ToList().Count(), JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(0, JsonRequestBehavior.AllowGet);
    
            }
