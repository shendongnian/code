    [HttpPost]
    public ActionResult Update(Product productPassedInFromView)
    { 
        Product productToEdit = db.Products.Find(productPassedInFromView.ID);
    
        productToEdit.Property1 = productPassedInFromView.Property1;
        productToEdit.Property2 = productPassedInFromView.Property2;
        //Continue for all the fields you want to edit.
    
        _db.SaveChanges();
    }
