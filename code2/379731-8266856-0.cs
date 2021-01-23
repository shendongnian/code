    public bool ValidateCustomer(string username, string password) 
    { 
        var user = this.DataContext.Customers 
                                   .Where(s => s.ActiveInWebLogin == 1 && 
                                    s.WebAccount == username && 
                                    s.Password == password) 
                                   .SingleOrDefault(); 
  
        if (user != null)
        { 
            this.UpdateCustomerLastUpdateStatus(user); 
            return true; 
        }
        return false;
    }
     
    public void UpdateCustomerLastUpdateStatus(Customers c) 
    { 
        c.LastWebLogIn = DateTime.Now; 
        this.DataContext.SaveChanges(); 
    }
