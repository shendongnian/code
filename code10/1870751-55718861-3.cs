    public JsonResult GetAllAttach(int headerId)
    {
        using (car_monitoringEntities contextObj = new car_monitoringEntities())
        {
            var attachList = contextObj.car_taxcomputationattachment
                                       .Where(x => x.headerID == headerId)
                                       .ToList();
            return Json(attachList, JsonRequestBehavior.AllowGet);
        }
    }
