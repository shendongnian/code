    public ActionResult EditProduct(int? id)  
    {
        Product prod = _productRepository.Get(id);// code to retrieve product from database
        if (prod != null)
        {
           return View(prod); 
        }
        else
        {
           return RedirectToAction("Error"); // or whatever...
        }
    } 
