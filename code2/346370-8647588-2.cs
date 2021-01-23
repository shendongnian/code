    public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product prod = context.Products.Where(p => p.ProductID == product.ProductID).FirstOrDefault();
                prod.Category = product.Category;
                prod.Description = product.Description;
                prod.ImageData = product.ImageData;
                prod.ImageMimeType = product.ImageMimeType;
                prod.Name = product.Name;
                prod.Price = product.Price;
            }
            context.SaveChanges();
        }
