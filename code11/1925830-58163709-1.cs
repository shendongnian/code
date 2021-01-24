    var customer = new Customers()
        {
            Id = customer3.Id,
            Address = customer3.Address,
            Contact = customer3.Contact,
            Name = x.Name,
            CustomerStatus = new List<CustomerStatus>
            {
                customer3.CustomerStatus.OrderByDescending(y => y.Date).FirstOrDefault()
            }
        })
