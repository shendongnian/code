    Category c = new Category 
    {
        ID = 5
    };
    ctx.AttachTo("Categories", c);
    
    Product p = new Product
    {
       ID = 5,
       Name = "Bovril"
    };
    ctx.AddToProducts(p);
    
    p.Category = c;
    ctx.SaveChanges();
