    public bool ValidateCustomer(string username, string password)
        {
    
             var customer =           this.DataContext
                            .Customers
                            .Where(s => s.ActiveInWebLogin == 1
                                        &&
                                        s.WebAccount == username
                                        &&
                                        s.Password == password
                                   )
                            .SingleOrDefault()
    
            if (customer != null)
                return this.UpdateCustomerLastUpdateStatus(customer);
    
            return false;
    
        }
        public void UpdateCustomerLastUpdateStatus(Customer c)
        {
    		try
    		{
    			c.LastWebLogIn = DateTime.Now;
    			this.DataContext.SaveChanges();
    			return true;
    		}
    		Catch(Exception ex)
    		{
    			// Log the error
    			return false;
    		}
        }
