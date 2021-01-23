    public partial class Connector
    {
        public void GetAllCustomers() 
        {
            var _foo = new FooService();
            customerEntity[] customers = _foo.getCustomerList;
            foreach (customerEntity customer in customers)
            {
                GetSingleCustomer(customer);
            }
        }
        public void GetSingleCustomer(customerEntity customer)
        {
            var id = customer.foo_id;
            // etc 
        }
    }
