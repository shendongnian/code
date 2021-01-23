        public IList<Product> GetProductsByCategoryId(int categoryId)
        {
            IList<Product> products;
            using (var context = new NorthwindData())
            {
                SqlParameter categoryParam = new SqlParameter("@categoryID", categoryId);
                products = context.Database.SqlQuery<Product>("Products_GetByCategoryID @categoryID", categoryParam).ToList();
            }
            return products;
        }
        public Product GetProductById(int productId)
        {
            Product product = null;
           
            using (var context = new NorthwindData())
            {
                SqlParameter idParameter = new SqlParameter("@productId", productId);
                product = context.Database.SqlQuery<Product>("Product_GetByID @productId", idParameter).FirstOrDefault();
            }
            return product;
        }
