     public static void Add(Product product)
        {
            using (var repo = ProductRepository.Repository) 
            {
               repo.ProductTable.Add(product);
               repo.SaveChanges();
            }
        }
