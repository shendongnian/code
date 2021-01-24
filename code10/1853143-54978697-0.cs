    public ActionResult QueryInfo(int? id)
    {
        ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "ServiceName", id);
        return View();
    }
