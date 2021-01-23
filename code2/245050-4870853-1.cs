    public class ProductItemByFruitComparer : IEqualityComparer<ProductItem>
    {
        public bool Equals(ProductItem x, ProductItem y)
        {
            // Case-insensitive comparison of Fruit property of both objects evaluates equality between them
            return x.Fruit.Equals(y.Fruit, StringComparison.CurrentCultureIgnoreCase);
        }
        public int GetHashCode(ProductItem obj)
        {
            // Since we are using Fruit property to compare two ProductItems, we return Fruit's HashCode in this method
            return obj.Fruit.GetHashCode();
        }
    }
