    [HttpPost]
    public ActionResult Edit(EditProductViewModel viewModel) {
    	if (ModelState.IsValid) {
    		var product = repository.Products.FirstOrDefault(p => p.Id == viewModel.Id);
    		// TODO - null check of product
    		// now lefty righty
    		product.Name = viewModel.Name;
    		product.Description = viewModel.Description;
    		
    		if (viewModel.Image.ContentLength > 0) {
    			product.ImageMimeType = image.ContentType; //  wouldn't trust this (better to lookup based on file extension)                
    			product.ImageData = new byte[image.ContentLength];                 
    			image.InputStream.Read(product.ImageData, 0, image.ContentLength); 
    		}
    
    		repository.SaveProduct(product);
    		return RedirectToAction("Index");
    	}
    
    	return View(viewModel);
    }
