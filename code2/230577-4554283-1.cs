    class ProductOption
    {
        Product _Product;
        public virtual Product Product
        {
            get { return _Product; }
            set
            {
                _Product = value;
                _Product.AddOptionInternal(this);
            }
        }
    }
