    private void TestMethod()
    {
        Task<Customer> task = GetCustomers(); // call async method as sync and get task as result
        task.Wait(); // wait executing the method
        var customer = task.Result; // get's result.
        Debug.WriteLine(customer.Name); //print customer name
    }
    public class Customer
    {
        public Customer()
        {
            new ManualResetEvent(false).WaitOne(TimeSpan.FromSeconds(5));//wait 5 second (long term operation)
        }
        public string Name { get; set; }
    }
    private Task<Customer> GetCustomers()
    {
        return Task.Run(() => new Customer
        {
            Name = "MyName"
        });
    }
