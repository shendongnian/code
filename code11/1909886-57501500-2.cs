    public ActionResult loaddata()
    {
    ViewBag.TransNum = TempData["ReqNo"];
    TempData.Keep();
    String ReqID = Convert.ToString(TempData["ReqNo"].ToString());
          
    using (ICSContext dc = new ICSContext())
    {
    dc.Configuration.LazyLoadingEnabled = false; 
    var data = dc.ICS_Orders.Where(s => s.RequisitionNumber == ReqID).OrderBy(a => a.RequisitionNumber).ToList();
                
    return Json(new
    {
    data = data
    }, JsonRequestBehavior.AllowGet);
    }
    }
