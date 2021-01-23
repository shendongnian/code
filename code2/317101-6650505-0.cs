	DataHubContext context = new DataHubContext();
	public IQueryable<Payment> GetPayments()
	{
		return context.Payments;
	}
   	public void Dispose()
	{
		context.Dispose();
	}
