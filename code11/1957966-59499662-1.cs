    void ProcessOrder(object sender, EventArgs e)
    {
        orderProcessTimer.Stop();
        var count = Orders.Count;
        if(count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                var order = PacMan<AllOrderStruct>.Unpack(Orders.Dequeue());
                switch (order.Action)
                {
                    case Data.Action.Add: AddNewOrder(order); break;
                    case Data.Action.Delete: RemoveOrder(order); break;
                    case Data.Action.Modify: ModifyOrder(order); break;
                    case Data.Action.Execute: UpdateOrderOnExecution(order); break;
                }
            }             
        }
        orderProcessTimer.Start();
    }
