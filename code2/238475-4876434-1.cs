    private static void AttachRelatedObjects(
        ObjectContext currentContext,
        SalesOrderHeader detachedOrder,
        List<SalesOrderDetail> detachedItems)
    {
        // Attach the root detachedOrder object to the supplied context.
        currentContext.Attach(detachedOrder);
    
        // Attach each detachedItem to the context, and define each relationship
        // by attaching the attached SalesOrderDetail object to the EntityCollection on 
        // the SalesOrderDetail navigation property of the now attached detachedOrder.
        foreach (SalesOrderDetail item in detachedItems)
        {
            currentContext.Attach(item);
            detachedOrder.SalesOrderDetails.Attach(item);
        }
    }
