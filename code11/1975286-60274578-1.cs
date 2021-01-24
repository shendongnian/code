    public void RemoveDisplayingDataValidation()
    {
        ModelState.Remove("ProductName");
        //remove other Displaying properties' validation
    }
    
    [HttpPost]
    public IActionResult Cart(CMyViewModel viewModel)
    {
        RemoveDisplayingDataValidation();
        if (ModelState.IsValid)
        {
            SetProductQuantity (viewModel.ProductQuantity) ;
            return RedirectToAction("Cart");
        }
        CMyViewModel viewModel = BuildViewModel () ;
        return View(viewModel);
    }
