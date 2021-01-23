    [HttpGet]
    public ActionResult AddProduct()
    {
        //for initialize viewmodel
        var productViewModel = new ProductViewModel();
        
        //assign values for viewmodel
        productViewModel.ProductName = "Smart Phone";
        //send viewmodel into UI (View)
        return View("AddProduct", productViewModel);
    }
