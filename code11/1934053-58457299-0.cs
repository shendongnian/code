    public class Item
    {
        public string ItemGroup { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public float Price
        {
            get
            {
                // your TotalValue logic since you already have quantity and unit Price
                // something like
                return Quantity * UnitPrice;
            }
        }
    }
