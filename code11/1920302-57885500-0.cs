    public ActionResult GetTransID()
    {
    	 AcctgContext db = new AcctgContext();
    	 return Json(db.CATransactions.OrderByDescending(i => i.TransID).FirstOrDefault(x => new
    	 {
    		 TransID= x.TransID + 1
    	 }).ToList(), JsonRequestBehavior.AllowGet);
    }
