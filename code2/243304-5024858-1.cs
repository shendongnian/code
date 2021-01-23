    [HttpGet]
    public ActionResult Create()
    {
       var model = new CreateOrderViewModel
       {
          Products = db.Products
                       .ToList() // this will fire a query, basically SELECT * FROM Products
                       .Select(x => new SelectListItem
                        {
                           Text = x.ProductName,
                           Value = x.ProductId
                        });
       };
      
       return View(model);
    }
