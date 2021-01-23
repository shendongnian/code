    Expression<Func<Customer, bool>> e1 = 
        DynamicExpression.ParseLambda<Customer, bool>("City = \"London\"");
    Expression<Func<Customer, bool>> e2 =
        DynamicExpression.ParseLambda<Customer, bool>("Orders.Count >= 10");
    IQueryable<Customer> query =
        db.Customers.Where("@0(it) and @1(it)", e1, e2);
