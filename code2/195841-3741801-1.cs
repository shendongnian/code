         public IQueryable<Product> GetAllProducts() {
             return fakeProducts.AsQueryable();
         }
         public Product Add(Product Product) {
             fakeProducts.Add(Product);
             return Product;
         }
     }
