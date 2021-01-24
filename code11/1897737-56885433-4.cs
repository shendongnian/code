     public static IQueryable<Product> Filter(this IQueryable<Product> products, Filter filter)
        {
            // TODO: exception if products == null
            if (filter == null)
            {
                // don't filter, return the original collection:
                return products;
            }
            else
            {
                return products.Where (product =>
                     (filter.ProductId == null || filter.ProductId == product.ProductId)
                  && (filter.LocationId == null || filter.LocationId == product.LocationId)
                  && ...);
            }
    }
        }
