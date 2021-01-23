	public CustomerRepository : ICustomerRepository
	{
		Type customerType;
		// ISession[Factory] injection omitted for brevity
		public CustomerRepository(IUnityContainer container)
		{
			registration = container.Registrations.FirstOrDefault(
				x => x.RegisteredType.Equals(ICustomer));
			if(registration == null) 
			{
				throw new ApplicationException(
					"No ICustomer implementation was registered.");
			}
			customerType = registration.MappedToType;
		}
		public ICustomer Retrieve(int id)
		{
			return _session.Get(customerType, id);
		}
	}
