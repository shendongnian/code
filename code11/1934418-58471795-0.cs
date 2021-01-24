    public void UpdateUserProfile(Customer newCustomer) {
    
        var customer = _context.Customers.First(c = >c.Id == customerId);
    
        var isNeedUpdateAccount = IsDifferent(customer, newCustomer)
    
        if(isNeedUpdateAccount){
        //TODO: Update the current Customer
         _context.SaveChanges();
        }
        
    
        if (isNeedUpdateAccount) {
            UpdateAccount(customer);
        }
    }
    
    public bool IsDifferent(Customer c1, Customer c2)
    {
        foreach (PropertyInfo property in c1.GetType().GetProperties())
        {
            object value1 = property.GetValue(c1, null);
            object value2 = property.GetValue(c2, null);
            if (!value1.Equals(value2))
            {
                return true;
            }
        }
        return false;
    }
