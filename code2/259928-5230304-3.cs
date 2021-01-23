    public class Product<TPriceValue>
    {
        public virtual int Id { get; set; }
        public virtual TPriceValue PriceList { get; set; }
    
        public Product()
        {
            // NOTE/EDIT: You wouldn't initialize "PriceList" here...
        }
    }
