    [ApiController]
    [Route("[controller]")]
    public class ShopController : ControllerBase
    {
        ShopContext _ctx;
        CartService _cart;
        OrderService _order;
        
        public ShopController(ShopContext ctx, CartService cart, OrderService order)
        {
            Console.WriteLine($"Context in ShopController: {ctx.Id}");
            _ctx = ctx;
            _cart = cart;
            _order = order;
        }
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var carts = await _cart.List();
            var orders = await _order.List();
            return (from c in carts select c.Name).Concat(from o in orders select o.Name);
        }
        [HttpPost]
        public async Task Post(string name)
        {
            await _cart.Create(name);
            await _order.Create(name);
            await _ctx.SaveChangesAsync();
        }
    }
