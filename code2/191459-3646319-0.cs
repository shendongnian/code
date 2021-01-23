    public static IQueryable<CustomerDTO> ToCustomerDTO(
        IQueryable<Customer> customers)
    {
        return
            from customer in customers
            select new CustomerDTO()
            {
               ...
            };
    }
