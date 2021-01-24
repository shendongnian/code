    public async Task Update(Order order)
    {
        var ordersToRemove = await context.Orders
            .Where(r => r.CustomerID == 100 || r.CustomerID == 120)
            .ToListAsync();
        context.Orders.RemoveRange(ordersToRemove);
        order.EmployeeID = 2;
        context.Update(order);
        await context.SaveChangesAsync();
    }
