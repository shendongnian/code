        public void RemoveLine( Product product )
        {
            var helper = new RemoveAllHelper();
            helper.product = product;
            lineCollection.RemoveAll( helper.TheMethod );
        }
        class RemoveAllHelper
        {
            public Product product;
            public bool TheMethod( CartLine p ) { return p.Product.ProductID == product.ProductID; }
        }
