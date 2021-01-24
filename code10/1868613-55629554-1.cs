    public Customer getById(int id = -1)
    {
        Customer t = dbProducts.Customers
            	.Where(h => h.customerID == id)
				.Include(x => x.PropertyLeaseContracts)
				  .ThenInclude(x => x.LeaseContract)
				.Include(x => x.PropertyLeaseContracts)
                  .ThenInclude(x => x.Property)
                .FirstOrDefault();
        return t;
    }
