     public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
	{
	    public CustomerRepository(ObjectContext context) : base(context) { }
	 
	    public IList<Customer> NewlySubscribed()
	    {
	        var lastMonth = DateTime.Now.Date.AddMonths(-1);
	 
	        return GetQuery().Where(c => c.Inserted >= lastMonth)
	        .ToList();
	    }
	 
	    public Customer FindByName(string firstname, string lastname)
	    {
	        return GetQuery().Where(c => c.Firstname == firstname && c.Lastname == lastname).FirstOrDefault();
	    }
	}
