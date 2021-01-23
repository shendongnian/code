    using (YourDataContext ctx = new YourDataContext())
    {
        Customer c = from c in ctx.Customers
                     where c.CustomerId == ID
                     select c;
        c.ordersTillNow++;
        ctx.SubmitChanges()
    }
