    public class ProductInventoryInfo
    {
        public string ProductName { get; set; }
        public override bool Equals(object obj)
        {
            if (!(obj is ProductInventoryInfo))
            {
                return false;
            }
            var other = (ProductInventoryInfo)obj;
            return this.ProductName == other.ProductName;
        }
        protected bool Equals(ProductInventoryInfo other)
        {
            return ProductName == other.ProductName;
        }
        public override int GetHashCode()
        {
            return (ProductName != null ? ProductName.GetHashCode() : 0);
        }
    }
