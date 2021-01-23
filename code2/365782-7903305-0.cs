    public class CustomerFacade()
    {
    public bool Save(Customer c)
    {
        VerifyCustomer(c);
    // lots of other steps which the caller does not need to know
        SaveorUpdateCustomer(c);
        }
        private void VerifyCustomer(Customer c)
        {
        }
        private void SaveorUpdateCustomer(Customer c)
        {
        }
        }
    
    public class CustomerController()
    {
    public bool Save(Customer c)
    {
    return new CustomerFacade().Save(c);
    }
    }
