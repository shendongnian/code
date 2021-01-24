    public ActionResult Product(int id)
    {
          var product = productRepository.GetById(id);
          if (string.IsNullOrEmpty(Request.Headers["X-PJAX"]))
              return View(product);
          else
              return PartialView("/Views/Home/Product.cshtml", product);
    }
  
         
         
         
