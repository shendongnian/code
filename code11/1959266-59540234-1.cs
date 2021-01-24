    var product = new Product();
    product.Category = new Category() { Id = 1, Name = "Category 1" };
    product.Name = "Product 1000";
    product.Price = 1000;
    product.Description = "Product 1000 Description";
    using (var db = new TestDBEntities())
    {
        db.Entry(product.Category).State = EntityState.Unchanged;
        db.Entry(product).State = EntityState.Added;
        db.SaveChanges();
    }
