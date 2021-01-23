        var customer= db.customers.AsNoTracking().Single(c=>c.id==1);
        customer.name=santhosh;
        customer.city=hyd;
        ctx.customers.Attach(customer);
        ctx.ObjectStateManager.ChangeObjectState(customer, System.Data.EntityState.Modified);
        
