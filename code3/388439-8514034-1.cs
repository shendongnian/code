        public void RemoveLine( Product product )
        {
            lineCollection.RemoveAll( TheMethod );
        }
        public static bool TheMethod( CartLine p ) { return p.Product.ProductID == 5; }
