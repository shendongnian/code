    IQueryable<Order> query = Entities.Orders;
    if (this.LoggedInUser.UserId == 9)
    {
        query = query.Where(o => o.Status.Equals(OrderStatus.NewOrder));
    }
    else if (this.LoggedInUser.UserId == 22)
    {
        query = query.Where(o => o.AssignedToUserId.Equals(22));
    }
    List<Order> orders = query.ToList();
