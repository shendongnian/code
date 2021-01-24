    public JsonResult GetAllAttach(int headerId)
    {
        using (car_monitoringEntities contextObj = new car_monitoringEntities())
        {
            var attachList = contextObj.car_taxcomputationattachment
                                       .Where(x => x.headerId == x.headerId)
                                       .ToList();
            return Json(attachList, JsonRequestBehavior.AllowGet);
        }
    }
