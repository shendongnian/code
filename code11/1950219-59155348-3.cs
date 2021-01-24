    private readonly IGame _gameRepository;
    private readonly ICartItem _cartRepository;
    public CartController(IGame gameRepository, ICartItem cartRepository)
    {
        _gameRepository = gameRepository;
        _cartRepository = cartRepository;
    }
