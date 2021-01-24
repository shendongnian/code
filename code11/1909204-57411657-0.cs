    var options = new SubscriptionCreateOptions
    {
        CustomerId = customer.Id,
        Items = items,
        Expand = new List<string>() { "latest_invoice.payment_intent" }
    };
    
    var subscriptionServices = new SubscriptionService();
    Subscription subscription = subscriptionServices.Create(options);
