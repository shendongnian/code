    if (context1.Entry(myEntity).State != EntityState.Detached);
    {
        ((IObjectContextAdapter)context1).ObjectContext.Detach(myEntity);
    }
    context2.MyEntities.Attach(myEntity);
