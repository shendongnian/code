    public class Product<TPriceValue>
    {
        public virtual int Id { get; set; }
        public virtual IDictionary<string, TPriceValue> PriceList { get; set; }
    
        public Product()
        {
            this.PriceList = new Dictionary<string, decimal>();
        }
    }
