    public override OrderCollection<Order> Orders
    {
        get { return cogs; }
        set 
        {
            // assert value is OrderCogCollection<OrderCog>  
            cogs = (OrderCogCollection<OrderCog>)value; 
        }
    }
    public OrderCogCollection<OrderCog> OrderCogs
    {
        get { return cogs; }
        set { cogs = value; }
    }
