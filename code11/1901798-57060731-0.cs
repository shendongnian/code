    public static Expression<Func<Order, OrderDTO>> ToDTO = x => new OrderDTO
    {
        OrderName = x.Name,
        OrderItems = x.Items.AsQueryable().Select(y => new OrderItemDTO { OrderItemName = y.Name }).ToList()
    };
