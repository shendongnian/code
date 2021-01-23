    db.Categories    
      .GroupJoin(
         db.Products,
         Category => Category.CategoryId,
         Product => Product.CategoryId,
         (x, y) => new { Category = x, Products = y })
      .SelectMany(
         xy => xy.Products.DefaultIfEmpty(),
         (x, y) => new { Category = x.Category, Product = y })
      .Select(s => new
      {
         CategoryName = s.Category.Name,     
         ProductName = s.Product.Name   
      })
