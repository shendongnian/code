    public ActionResult Index()
    {
        //if you want to load all the clients by default
        test_Db_Context db = test_Db_Context();
        List<ViewNewOrderSum> orderSums; 
        orderSums = db.ViewNewOrderSum.ToList();
        return View(orderSums);
    }
     [HttpPost]
     public ActionResult Index(string searchTerm) {
         
         test_Db_Context db = test_Db_Context();
            List<ViewNewOrderSum> orderSums;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                orderSums = db.ViewNewOrderSum.Where(x => 
                                   x.ClientName.Equals(searchTerm)).ToList();
            }
          
         return View(result);
     }
