    public class CustomerRepository : ICustomerRepository
    {
        IServiceScopeFactory _serviceScopeFactory
        public CustomerRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public async Task<Customer> Create(Customer customer)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();              
                await context.Customers.AddAsync(customer);
                return customer;
            }
           
            return customer;
            
        }
    }
