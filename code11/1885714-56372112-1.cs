    // GET: TerminalReceipts
    [HttpPost]
    public ActionResult Index(int id )
    {
         var model = TRBL.GetTransactionTestsData(id);
        //var model = new TerminalReceiptsVM();
        return View(model);
    }
