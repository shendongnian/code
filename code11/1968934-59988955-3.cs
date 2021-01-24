    int id = // ... get the Product ID from your XML
    string name = // ... get the Product Name from your XML
    //... etc.
    string categoryName = // ... get the Category Name from your XML
    var category = categories.SingleOrDefault(c => c.Name == categoryName);
    if (category = null)
    {
        // It doesn't exist yet, so add it
        category = new Category();
        category.Name = categoryName;
        category.CategoryId = // ... whatever logic you use to determine this
        categories.Add(category);
    }
    return new Product
    {
        ProductId = id,
        Name = name,
        // etc.
        Category = category
    };
    
