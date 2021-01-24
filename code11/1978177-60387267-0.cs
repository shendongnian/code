    public ActionResult Index()
    {
        // Include will let you to load Supplier information along with purchase invoices
    	return View(db.purchaseInvoices.Include(pi => pi.Supplier).ToList());
    }
