    using (DBEntities context = new DBEntities())
    {
        //Must attach first and change the state to modified
        context.Products.Attach(product);
    
        //If you are using .Net 4.1 then you can use this line instead:
        //context.Entry(
        context.ObjectStateManager.ChangeObjectState(product, EntityState.Modified);
        
        context.SaveChanges();
    }
