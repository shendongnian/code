    IEnumerable<ProductsViewModel> productList;
    using (var context = new Trainee1334Context())
    {
         productList = context.Products.Where(p => p.ProdcuctName.Contains("Book"))
              .Select(p => new ProductsViewModel() 
              {
                 Name = p.Name,
                 Price = p.Price,
                 // initialize all viewmodel properties
              });
    }
    return productList;
