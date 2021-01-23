    public class Cart
    {
        //Properties from cart - Just using name as an example.
        public string name { get; set; }
    }
    public class CartRepository
    {
        public List<Cart> GetById(int cartId)
        {
            List<Cart> carts = new List<Cart>();
            
            // Do all sql work including setting up connection, command, ect.
            
            while(reader.read())
            {
                // Map your reader to your cart object above.
                Cart c = new Cart();
                c.name = reader["name"].ToString();
                carts.add(c);
            }
           
            return carts;
        }
    }
