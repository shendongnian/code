    class Product
    {
        public Product()
        {
            _Options = new List<ProductOption>();
        }
        ICollection<ProductOption> _Options;
        public virtual IEnumerable<ProductOption> ProductOptions
        {
            get { return _Options.Select(x => x); }
        }
        public virtual AddOption(ProductOption option)
        {
            option.Product = this;
        }
        protected internal virtual AddOptionInternal(ProductOption option)
        {
            _Options.Add(option);
        }
    }
