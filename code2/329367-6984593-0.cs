    int StatusOrder(Status status) 
    {
        switch(status.Id)
        {
           case 1: return 5;
           case 2: return 1;
           case 4: return 3;
           //etc
        }
    }
    List<Order> orders; //no need to create a list here
    using (DBDataContext context = new DBDataContext())
    {
        orders = (from o in context.Orders
            orderby (o.PriorityID.HasValue ? o.PriorityID : Int32.MaxValue)  ascending,
                    SorderOrder(o.Status)
            select o).ToList();
    }
