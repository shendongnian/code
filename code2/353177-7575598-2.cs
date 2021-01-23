    public void UpdateCustomer(int customerId, string ...../*it might be a customer type also*/)
    {
       using (var ctx= CreateContext())
     {
        var customer = ctx.Customers.FirstOrDefault(c=>c.CustomerId = customerId);
        if ( customer != null)
        {
               /*code update 20 properties */
        }
     }
    }
