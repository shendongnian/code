    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService shoppingCartService;
        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }
    }
    public class ShoppingCartService : IShoppingCartService 
    {
        private readonly MrbFarmsDbContext context; 
        public ShoppingCartService(MrbFarmsDbContext context)
        {            
            this.context = context;
        }
    }
      
