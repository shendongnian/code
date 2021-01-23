    class ProductCollection : IEnumerable<Product> {
        public IEnumerable<Product> GetEnumerator() {
           // ... return Product objects here.
        }
        public IEnumerable<int> AsIntegerCollection() {
           // yield the integer collection here
        }
        public IEnumerable<string> AsStringCollection() {
           // yield the string collection here
        }
    }
