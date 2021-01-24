    //using System.Data.Entity;
    var product = new Product();
    product.CategoryId = 1;
    product.Name = "Product 1000";
    product.Price = 1000;
    product.Description = "Product 1000 Description";
    using (var db = new TestDBEntities())
    {
        db.Entry(product).State = EntityState.Added;
        db.SaveChanges();
    }
