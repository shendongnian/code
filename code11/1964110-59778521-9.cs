    public class CartService
    {
        ShopContext _ctx;
        public CartService(ShopContext ctx)
        {
            _ctx = ctx;
            Console.WriteLine($"Context in CartService: {ctx.Id}");
        }
        public async Task<List<Cart>> List() => await _ctx.Carts.ToListAsync();
        public async Task<Cart> Create(string name)
        {
            return (await _ctx.Carts.AddAsync(new Cart {Name = name})).Entity;
        }
    }
    public class OrderService
    {
        ShopContext _ctx;
        public OrderService(ShopContext ctx)
        {
            _ctx = ctx;
            Console.WriteLine($"Context in OrderService: {ctx.Id}");
        }
        public async Task<List<Order>> List() => await _ctx.Orders.ToListAsync();
        
        public async Task<Order> Create(string name)
        {
            return (await _ctx.Orders.AddAsync(new Order {Name = name})).Entity;
        }
    }
