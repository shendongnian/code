    public class ShoppingCart
    {
        public List<CartItem> Items { get; private set; }
        public static SqlConnection conn = new SqlConnection(connStr.connString);
        public static readonly ShoppingCart Instance;
    
        static ShoppingCart RetrieveShoppingCart()
        {
            if (HttpContext.Current.Session["ASPNETShoppingCart"] == null)
            {
                    Instance = new ShoppingCart();
                    Instance.Items = new List<CartItem>();
                    HttpContext.Current.Session["ASPNETShoppingCart"] = Instance;  
            }
            else
            {
                Instance = (ShoppingCart)HttpContext.Current.Session["ASPNETShoppingCart"];
            }
            return Instance;
        }
    }
