    public void PrintForeignOrders(List<Orders> orders)
    {
        foreach(var order in orders)
        {
            if (order.IsForeign)
            {
                printer.PrintOrder(order.Number, order.Name);
            }
        }
    }
