    public Customer getById(int id = -1)
    {
        Customer t = dbProducts.Customers
            	.Where(h => h.customerID == id)
				.Include(x => x.PropertyLeaseContracts.Select(plc => plc.LeaseContract))
				.Include(x => x.PropertyLeaseContracts.Select(plc => plc.Property))
                .FirstOrDefault();
        return t;
    }
