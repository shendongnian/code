    public static class Program
    {
        public static void Main()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<OrderMappingProfile>());
            var mapper = config.CreateMapper();
            var orderList = new OrderDtoList { Orders = Enumerable.Range(1, 10).Select(i => new OrderDto { Id = i }).ToArray() };
            var orders = mapper.Map<List<Order>>(orderList);
        }
    }
