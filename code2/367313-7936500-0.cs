    public bool AddCustomer(Customer customer) {
      if(null != customer) {
        if(customerList.Count(c => c.Name == customer.Name) == 0) {
          customer.Add(customer);
          return true;
        }
      }
      return false;
    }
