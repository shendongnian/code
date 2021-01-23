      var customers = from c in context.Customer
                      select new NewCustomerType
                      {
                        Customer = c,
                        FirstName = c.Individual.Contact.FirstName,
                        LastName = .Individual.Contact.LastName,
                        .
                        .
                        .
                      };
