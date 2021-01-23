    class Customer
    {
        string name; // etc
        Address homeAddress;
        Order[] orders;
    }
    interface ICustomerTableGateway { ... }
    interface IAddressTableGateway { ... }
    interface IOrderTableGateway { ... }
    class CustomerRepository
    {
        Customer Get(int id)
        {
            customer = customerTableGateway.Get(id);
            customer.Address = addressTableGateway.Get(customer.id);
            customer.Orders = orderTableGateway.GetAll(customer.id);
        }
    }
