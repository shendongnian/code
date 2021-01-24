        using (var context = new PracticeEntities1())
        {
            var existingCustomer = context.Customers.FirstOrDefault(c => c.Email == customer.Email);
            if (existingCustomer != null) {
                existingCustomer.FirstName = customer.FirstName;
                // other fields you want to update
            }
            else
            {     
                context.Customers.Add(customer);
            }
            context.SaveChanges();
        }
