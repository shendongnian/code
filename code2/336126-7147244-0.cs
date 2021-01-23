    public bool UpdateCustomer(Customer customer){   
        Customer cust = entities.Customers.FirstOrDefault(c => c.ID == customer.ID);  
        cust.Forname = customer.Forename;   
        cust.Surname = customer.Surname   
        entities.SaveChanges(); 
    }
