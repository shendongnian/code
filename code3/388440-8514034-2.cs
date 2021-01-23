        public void RemoveLine( Product product )
        {
            lineCollection.RemoveAll( this.TheMethod );
        }
        public bool TheMethod( CartLine p ) { return p.Product.ProductID == this.targetProductID; }
