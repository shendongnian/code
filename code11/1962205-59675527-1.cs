    public ActionResult Index()
    {
        var cafeTableDetails = db.CafeTableDetails.Include(c => c.CafeTable).Include(c => c.Food);
        var totalOrders = cafeTableDetails.Sum(p => p.TotalAmount);
        var viewModel = new CafeTableViewModel 
                        { TotalOrders = totalOrders, CafeTableDetails = cafeTableDetails.ToList()}
        return View(viewModel);
    }
