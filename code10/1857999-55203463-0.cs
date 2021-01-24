    while (orderItemsResult.Read())
    {
       yield return new OrderItem()
       {
            ItemName = orderItemsResult.GetString("item_name"),
            Price = orderItemsResult.GetFloat("price"),
            Quantity = orderItemsResult.GetInt32("quantity")
        };
    }
