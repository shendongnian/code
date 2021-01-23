    class ProductCollection : IEnumerable<Product>
    {
        public IEnumerator<Product> GetEnumerator()
        {
           ...
        }
    
        public IEnumerator<string> ProductNames // a helper to enumerate product names
        {
           ...
        }
    
        public IEnumerator<int> ProductIds // a helper to enumerate product ids
        {
           ...
        }
    }
