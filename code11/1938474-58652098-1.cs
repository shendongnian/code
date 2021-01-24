    List<Customer> customers = Enumerable.Range(0, 10).Select(c =>
        new Customer
        {
            Name = "Pedro",
            Age = "20",
            Products = Enumerable.Range(0, 3).Select(p => new Product
            {
                Code = "1",
                Price = "400.00"
            }).ToArray()
        }).ToList();
