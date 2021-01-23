    int categoryIdOfNewProduct = 123;
    using (var context = new MyContext())
    {
        bool categoryExists = context.Categories
            .Any(c => c.Id == categoryIdOfNewProduct);
        if (categoryExists)
        {
            var newProduct = new Product
            {
                Name = "New Product",
                CategoryId = categoryIdOfNewProduct,
                // other properties
            };
            context.Products.Add(newProduct); // EF 4.1
            context.SaveChanges();
        }
        else
        {
            //Perhaps some message to user that category doesn't exist? Or Log entry?
        }
    }
