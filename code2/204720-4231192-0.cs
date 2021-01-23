    MyDbEntities bb = new MyDbEntities();
    
     //Add & Save new entry
     db.Product.AddObject(product);
     db.SaveChanges();
    
     //Reset entity
     db.ObjectStateManager.ChangeObjectState(product, System.Data.EntityState.Added);
     product.ProductId = 0;
