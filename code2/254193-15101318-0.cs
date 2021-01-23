    Task GetCustomersSynchronously()
    {
        Task t = new Task(async () =>
        {
            myCustomers = await GetCustomers();
        }
        t.RunSynchronously();
    }
