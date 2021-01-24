    var model = new GetCustomerDetailsViewmodel();
    model.Customer = context.Customers.SingleOrDefault(c => c.CustomerId == id);
    if (model.Customer != null)
    {
         model.Accounts = model.Customer.Dispositions.Select(x => x.Account).ToList();
         model.Cards = model.Customer.Dispositions.SelectMany(x => x.Cards).ToList();
         model.PermantentOrders = model.Accounts.SelectMany(x => x.PermenentOrder).ToList();
    }
