    var customerNew = new Customer
                      {
                          // ... set all the properties here
                      }
    var phoneNew = new CustomerPhone
                {
                    Number = customer.Number,
                    PhoneTypeId = 5
                };
    customerNew.CustomerPhones.Add(phoneNew);  // add new phone to the association
    var emailNew = new CustomerEmail
                {
                    Email = customer.Email
                };
    customerNew.CustomerEMails.Add(phoneNew);  // add new e-mail to the association
    db.Customers.AddObject(customerNew);
    db.SaveChanges();
