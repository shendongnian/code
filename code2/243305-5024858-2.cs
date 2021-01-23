    [HttpPost]
    public ActionResult Create(CreateOrderViewModel model)
    {
       try
       {
          // TODO: this manual stitching should be replaced with AutoMapper
          var newOrder = new Order
          {
             OrderDate = DateTime.Now,
             OrderProduct = new OrderProduct
             {
                ProductId = SelectedProductId
             }
          };
    
          db.Orders.AddObject(newOrder);
          return RedirectToAction("Index");
       }
       catch
       {
          return View();
       }
    }
