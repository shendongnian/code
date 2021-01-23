    [HttpPost]
    public ActionResult Create(string customerCode, int customerId, Order order)
    {
        var cust = _customerRepository.Get(customerId);
        cust.AddOrder(order);//this should carry the customerId to the order.CustomerId
    }
