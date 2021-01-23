    [HttpPost]
    public ActionResult Create()
    {
        //some operations first
        ...
        // binding will start here 
        var model = new Customer();
        UpdateModel(customer);
        ...
    }
