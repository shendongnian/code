    class ProductNameEqulity : IEqualityComparer<Product>
    {
        public bool Equals(Product p1, Product p2)
        {
            return p1.Name == p2.Name
        }
    
        public int GetHashCode(Product product)
        {
            return product.Name.GetHashCode();
        }
    }
