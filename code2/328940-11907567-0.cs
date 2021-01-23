    var customer= db.customers.AsNoTracking().Single(c=>c.id==1);     
    
    db.customers.Attach(customer);      
    customer.name=santhosh;     
    customer.city=hyd;     
    db.ObjectStateManager.ChangeObjectState(customer, System.Data.EntityState.Modified); 
    db.SaveChanges();
    
    db.Dispose();
