    class Order { /* skipped */ }
    class Customer { /* skipped */ }
    void Foo()
    {
        var orderId = Id<Order>.NewId();
        var customerId = Id<Customer>.NewId();
    
        bool sameIds = (orderId.Value == customerId.Value); // true
        bool sameObjects = orderId.Equals(customerId); // false
    }
