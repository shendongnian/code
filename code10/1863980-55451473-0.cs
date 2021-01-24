    [HttpPost]
          
    public ActionResult Submit(ItemViewModel model)
     {
       decimal? a = model.TotalPrice;
       Console.WriteLine(a);
       return View();
     }
       
    public ActionResult Submit()
      {
        return View();
      }
