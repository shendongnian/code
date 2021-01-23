    public class ProductFactory {
        public T Create<T>(Product product) 
          where T : IProduct, new() {
            return new T {
                Id = product.ProductId,
                Name = product.Name,
                PriceValue = product.Price.HasValue 
                    ? (double)product.Price.Value 
                    : 0.00    
            };
        }
    }
