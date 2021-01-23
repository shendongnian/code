    var predicate = PredicateBuilder.True<Customer>();
    if (searchingFirstName)
    {
        predicate = predicate.And(cust => cust.First == firstName);
    }
    if (searchingOrders)
    {
        // Some code to unify the .And() and .Or() cases
        Expression<Func<Order, bool>> subpredicate;
        Func<Expression<Func<Order, bool>>, Expression<Func<Order, bool>>, Expression<Func<Order, bool>>> joiner;
        if (orderMethodAny)
        {
            subpredicate = PredicateBuilder.True<Order>();
            joiner = PredicateBuilder.And;
        }
        else
        {
            subpredicate = PredicateBuilder.False<Order>();
            joiner = PredicateBuilder.Or;
        }
        if (searchingOrderDate)
        {
            // ...
        }
        if (searchingOrderWeight)
        {
            switch (orderOp)
            {
                case Op.Less:
                    subpredicate = joiner(subpredicate, ord => ord.Weight < orderWeight);
                    break;
                case Op.LessEqual:
                    subpredicate = joiner(subpredicate, ord => ord.Weight <= orderWeight);
                    break;
                case Op.Equal:
                    subpredicate = joiner(subpredicate, ord => ord.Weight == orderWeight);
                    break;
                case Op.GreaterEqual:
                    subpredicate = joiner(subpredicate, ord => ord.Weight >= orderWeight);
                    break;
                case Op.Greater:
                    subpredicate = joiner(subpredicate, ord => ord.Weight > orderWeight);
                    break;
                case Op.NotEqual:
                    subpredicate = joiner(subpredicate, ord => ord.Weight != orderWeight);
                    break;
            }
        }
        if (searchingOrderQuantity)
        {
           // ... 
        }
        if (searchingOrderItemName)
        {
            // ...
        }
        if (searchingOrderPrice)
        {
            // ...
        }
        predicate = predicate.And(cust => cust.Orders.Any(subpredicate));
    }
    if (searchingZipCode)
    {
        predicate = predicate.And(cust => cust.ZipCode == zipCode);
    }
    var query = Context.Customers.Where(predicate);
