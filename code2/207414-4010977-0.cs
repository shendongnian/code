    public IList<Order> ListOrders()
    {
        try
        {
            return (from o in db.Orders
                    where o.Id == this.Id
                    select o).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
