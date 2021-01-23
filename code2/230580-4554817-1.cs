    public class ProductOption
    {
        Product _product;
        public virtual Product Product
        {
            get { return _product; }
            set
            {
                _product = value;
                _product.AddOption(this);
            }
        }
    }
