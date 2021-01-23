	private Customer CreateBusinessCustomer(Thing thing, EventHandler tapHandler)
	{
		var customer = new BusinessCustomer(thing);
		customer.OnTapped = tapHandler;
	}
	private void Customer_OnTapped(object sender, EventArgs e)
	{
		// do something
	}
