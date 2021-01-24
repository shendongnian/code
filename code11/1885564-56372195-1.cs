    [HttpPost]
    public ActionResult ViewSsoProviders(MyViewModel model)
    {
         //Do a redirection to ViewSoProviders
         //ex.
         return RedirectToAction("ViewSsoProviders", new {nameFilter = model.NameFiler, bpIdFilter = model.BpIdFilter, protocolFilter= model.ProtocolFilter });
    }
