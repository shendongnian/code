    private Product GetProductById(int id) {
        //check if it's in the cache already
        var cachedEntity = myContext.ChangeTracker.Entries<Product>()
                               .FirstOrDefault(p => p.Entity.Id == id);
        if (cachedEntity == null) {
            //not in cache - get it from the database
            return myContext.Products.Find(id);
        } else {
            //we already have it - reload it
            cachedEntity.Reload();
            return cachedEntity.Entity;
        }
    }
