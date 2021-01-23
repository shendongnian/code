    ViewData.Model = new MyCustomViewData
    {
    Dish = db.Dishes.OrderByDescending(o => o.ID).Take(1);
    Blog = db.Bloggs.OrderByDescending(o => o.ID).Take(1);
    }
    
    return View();
