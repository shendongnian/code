    public IActionResult Index()
    {
        var orders = new List<Order>
        {
            new Order { OrderId = 1, OrderName = "Order # 1" },
            new Order { OrderId = 2, OrderName = "Order # 2" }
        };
        var viewModel = new OrdersViewModel() {
            Orders = orders,
            Selected = orders.LastOrDefault().OrderId    // get last order
        };
        return View(viewModel);
    }
