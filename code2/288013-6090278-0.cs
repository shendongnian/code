    public class CartCollectionMap : CommerceCollectionMap<CartItem> {}
            
        public class CartMap: SubclassMap<Cart>
        {
            public CartMap()
            {
                KeyColumn("CommerceCollection_id");
            }
        } 
