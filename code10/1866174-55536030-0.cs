     public ActionResult Index(int? seraching)
        {
           if (seraching.HasValue){
     return View(_context.Customers.Where(x=>x.Customer_Mobile.ToString().Contains(seraching.ToString())).ToList());}
    else{return View(_context.Customers.ToList())}
        }
