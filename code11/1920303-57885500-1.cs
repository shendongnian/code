    public ActionResult GetTransID()
    {
    	 AcctgContext db = new AcctgContext();
    	 return Json(db.CATransactions.OrderByDescending(i => i.TransID).Select(i=>new
    	 {
    		 TransID= x.TransID + 1
    	 }).FirstOrDefault(), JsonRequestBehavior.AllowGet);
    }
