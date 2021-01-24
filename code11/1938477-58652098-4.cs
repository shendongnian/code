    List<Customer> customers = new List<Customer>();
    for (int i = 0; i < 10; i++)
    {
        // Create a new customer
        Customer customer = new Customer
        {
            Name = "Pedro",
            Age = "20",
        };
        // Create an array of products since Customer expects this type
        Product[] products = new Product[3];
        for (int j = 0; j < products.Length; j++)
        {
            products[j] = new Product
            {
                Code = "1",
                Price = "400.00"
            };
        }
        // Add the array to our customer
        customer.Products = products;
        // Add our customer to the list
        customers.Add(customer);
    }
