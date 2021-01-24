    IList<OrderItem> OrderItemsList = new List<OrderItem>();
    while (orderItemsResult.Read())
    {
        var orderItem = new OrderItem()
        {
            ItemName = orderItemsResult.GetString("item_name"),
            Price = orderItemsResult.GetFloat("price"),
            Quantity = orderItemsResult.GetInt32("quantity")
        };
        // add to the list
        OrderItemsList.Add(orderItem);
    }
