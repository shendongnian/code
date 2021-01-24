    UpcomingInvoiceOptions options = new UpcomingInvoiceOptions()
    {
        CustomerId = "cus_XXXXXXXXXXXXX",
        SubscriptionId = "sub_XXXXXXXXXXXX",
        SubscriptionProrationDate = DateTime.UtcNow,
        SubscriptionItems = new List<InvoiceSubscriptionItemOptions>()
        {
            new InvoiceSubscriptionItemOptions()
            {
                Id = "si_XXXXXXXXXXXXXX", // Current Sub Item
                PlanId = "plan_XXXXXXXXXXXX" // New plan
            }
        }
    };
    InvoiceService service = new InvoiceService();
    var result = service.Upcoming(options);
