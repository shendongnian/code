        using (var context = new PracticeEntities1())
        {
            var existingCustomer = context.Customers.FirstOrDefault(c => c.Email == customer.Email);
            if (existingCustomer != null) {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Address = customer.Address;
                existingCustomer.CompanyName = customer.CompanyName;
                existingCustomer.Phone = customer.Phone;
            }
            else
            {     
                context.Customers.Add(customer);
            }
            context.SaveChanges();
        }
