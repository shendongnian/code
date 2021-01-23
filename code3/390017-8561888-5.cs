    public ActionResult CheckView()
    {
        var model = new StoreModel
        {
            Products = new[]
            {
                 new ProductModel { ProductName = "product 1", Selected = true },
                 new ProductModel { ProductName = "product 2", Selected = false },
                 new ProductModel { ProductName = "product 3", Selected = true },
            }.ToList()
        };
    
        return View(model);
    }
