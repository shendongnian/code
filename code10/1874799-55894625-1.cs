    [HandleError(View = "Your_Error_View")]
    public ActionResult Create(Invoice invoice)
    {
      if(ModelState.isValide)
      {
        try
        {
           invoiceBll.AddInvoice(invoice);
           return RedirectToAction("Index");
        }
        catch(BusinessRulesException ex)
        {
             ViewBag.Message = ex.Message;
        }
      }
    }
