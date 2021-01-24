    public static IQueryable<TModel> GroupByExpression(List<string> propertyNames, IQueryable<TModel> sequence)
    {
        var param = Expression.Parameter(typeof(TModel), "item");
        Expression propertyExp = param;
        var body = Expression.New(typeof(TModel).GetConstructors()[0]);
        var bindings = new List<MemberAssignment>();
        var queryOrders = orders.AsQueryable();
        var orderBindings = new List<MemberAssignment>();
        //..more code was here, see question
        var orderParam = Expression.Parameter(typeof(OrderModel), "item");
        Expression orderPropertyExp = orderParam;
        var orderPropContact = typeof(OrderModel).GetProperty("Contact");
        orderPropertyExp = Expression.MakeMemberAccess(orderPropertyExp, orderPropContact);
        var orderPropContactId = orderPropContact.PropertyType.GetProperty("ContactId");
        orderPropertyExp = Expression.MakeMemberAccess(orderPropertyExp, orderPropContactId);
        var contactBody = Expression.New(typeof(ContactModel).GetConstructors()[0]);
        var contactMemerAssignment = Expression.Bind(orderPropContactId, propertyExp);
        orderBindings.Add(contactMemerAssignment);
        var contactMemberInit = Expression.MemberInit(Expression.New(contactBody, orderBindings);
        var orderContactMemberAssignment = Expression.Bind(orderPropContact, contactMemberInit);
        var orderMemberInit = Expression.MemberInit(Expression.New(typeof(OrderModel).GetConstructors()[0]), new List<MemberAssignment>() {orderContactMemberAssignment});
        //during debugging with the same model, I know TModel is OrderModel, so I can cast it
        //of course this is just a quick hack to verify it is working correctly in AgGrid, and it is!
        return (IQueryable<TModel>)queryOrders.Select(Expression.Lambda<Func<OrderModel, OrderModel>>(orderMemberInit, param));
    }
