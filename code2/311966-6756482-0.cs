        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                context.Entry(product).State = System.Data.EntityState.Modified;
            }
            context.SaveChanges();
        }
