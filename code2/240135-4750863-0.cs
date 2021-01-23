    public List<Customer> GetCustomerByStatus(CustomerStatus customerStatus)
		{
			var query = from customer in this.Customers
							select customer;
			switch (customerStatus)
			{
				case CustomerStatus.one:
					query = query.Where(customer => customer...);
					break;
				case CustomerStatus.two:
					query = query.Where(customer => customer...);
					break;
				case CustomerStatus.three:
					query = query.Where(customer => customer...);
					break;
			}
			return query.ToList();
		}
