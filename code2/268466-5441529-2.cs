    public class Sample {
    
        private int _productId;
    
        public int get_productId() {
            return _productId;
        }
    
        public void set_productId(int productId) {
            _productId = productId;
        }
    
        private Product _product = null;
    
        public Product get_product() {
            if (_product == null) {
                _product = new Product();
            }
            return _product;
        }
    
        public void set_product(Product product) {
            _product = product;
        }
    
    }
