    public class ShoppingCartService {
        private readonly IDatabaseFactory _storeDB;
  
        public ShoppingCartService(DatabaseFactory storeDB) {
            _storeDB = storeDB
        }
    
        public ShoppingCart GetCart(IdType cartId)
        {
            var cart = new ShoppingCart(_storeDB);
            cart.ShoppingCartId = cartId;
            return cart;
        }
    }
    public partial class ShoppingCart
    {
        private IDatabaseFactory _storeDB;
    
        public ShoppingCart(IDatabaseFactory storeDB)
        {
            _storeDB = storeDB;
        }
    
        private string ShoppingCartId { get; set; }
    
        public int OtherMethod()
        {
            ...
        }
    }
