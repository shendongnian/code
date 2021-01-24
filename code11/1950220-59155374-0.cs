    public class CartController:Controller
    {
        private readonly IGame _gameRepository;
        private readonly ICartItem _cartRepository;
        public CartController(IGame gameRepository, ICartItem cartRepository)
        {
            _gameRepository = gameRepository;
            _cartRepository = cartRepository;
        }
        public ViewResult Index()
        {
            var items = _cartRepository.GetCartItems();
            _cartRepository.CartItems = items;
            var sCVM = new CartViewModel
            {
                Cart = _cartRepository,
                CartTotal = _cartRepository.GetCartTotal()
            };
            return View(sCVM);
        }
}
