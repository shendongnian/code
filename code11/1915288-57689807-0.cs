    public class ProductItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int QuantityOnHand { get; set; }
        public int AmountOrdered { get; set; }
        public int AmountToReturn { get; set; }
        public string ReasonForReturn { get; set; }
        public int PaybackAmount { get; set; }
    }
    public class ProductModel
    {
        public ProductModel()
        {
            ProductItems = new List<ProductItem>();
        }
        public List<ProductItem> ProductItems { get; set; }
    }
