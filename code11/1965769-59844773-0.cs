    items.SelectMany(x => x.Products ?? Array.Empty<Product>).
          .Select(x => 
                {
                    var product = new ProductName(x);
                    return new OutputResponse
                    {
                        Name = product.Name,
                        Description = product.Description
                    };
                 }
