    public ActionResult ComfirmPay(string e, string TaxType, string CurrentAmt)
    {
      ViewBag.TotalAmt = e;
      ViewBag.CurrentAmt = CurrentAmt;            
      ViewBag.TaxType = TaxType;            
      return View();
    }
