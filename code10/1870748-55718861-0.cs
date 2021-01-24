    public JsonResult GetAllAttach(int attachmentID)
    {
        using (car_monitoringEntities contextObj = new car_monitoringEntities())
        {
            var attachList = contextObj.car_taxcomputationattachment
                                       .Where(x => x.headerId == x.attachmentID)
                                       .ToList();
            return Json(attachList, JsonRequestBehavior.AllowGet);
        }
    }
