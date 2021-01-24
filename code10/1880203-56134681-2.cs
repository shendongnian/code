    var customerProfile = context.Customers.Where(x => x.CustomerId == id).Select(x => new
            {
                Customer = x,
                Accounts = x.Dispositions.Select(d => d.Account),
                Cards = x.Dispositions.SelectMany(d => d.Cards).ToList(),
                PermanentOrders = x.Dispositions.SelectMany(d => d.Account.PermenentOrder),
            }).FirstOrDefault();
            if (customerProfile != null)
            {
                var model = new GetCustomerDetailsViewmodel();
                model.Customer = customerProfile.Customer;
                model.Accounts = customerProfile.Accounts.ToList();
                model.Cards = customerProfile.Cards.ToList();
                model.PermantentOrders = customerProfile.PermanentOrders.ToList();
            }
