    public class CustomerServiceManager : ICustomerServiceManager, BaseServiceManager
    {
       public IEnumerable<Customer> GetCustomerDetails(string lastName)
       {
            IEnumerable<IDataAccess> dataAccess = new List<IDataAccess>()
            {
                new MortgageCustomerDataAccess(new DatabaseFactory()), 
                new CurrentAccountCustomerDataAccess(new DatabaseFactory()),
                new SavingsAccountCustomerDataAccess(new DatabaseFactory())
            };
            IList<Customer> customers = new List<Customer>();
           foreach (IDataAccess nextDataAccess in dataAccess)
           {
                Customer customerDetail = nextDataAccess.GetDetails(lastName);
                customers.Add(customerDetail);
           }
            return customers;
       }
    }
