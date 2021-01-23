    var customerFilter = this.CustomerCriteria.FilterPredicate();
    // create an expression that shows us invoking the filter on o.Customer
    Expression<Func<Order, bool>> customerOrderFilter = 
        o => customerFilter.Invoke(o.Customer);
    // "Expand" the expression: this creates a new expression tree
    // where the "Invoke" is replaced by the actual predicate.
    result = result.And(customerOrderFilter.Expand())
