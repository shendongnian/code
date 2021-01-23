    public class Product
    {
        private IList<ProductOption> _options; 
        public Product()
        {
            _options = new List<ProductOption>();
        }
        public virtual IEnumerable<ProductOption> ProductOptions
        {
            get { return _options; }
        }
        public virtual AddOption(ProductOption option)
        {
            // equality must be overridden for this to work
            // Check contains to break out of endless loop
            if (!_options.Contains(options))
            { 
                _options.Add(option);
                option.Product = this;
            }
        }
    }
