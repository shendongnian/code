	MProduct.Behavior = MoleBehaviors.Fallthrough;
	MProduct.AllInstances.ModifyPriceSingle = (p, actual) =>
	{
		if (actual != 20.0f)
		{
			MolesContext.ExecuteWithoutMoles(() => p.ModifyPrice(actual));
		}
		else
		{
			Debug.WriteLine("Skipped setting price.");
		}
	};
	// Call the constructor that sets the price to 10.
	Product p1 = new Product();
	// Skip setting the price.
	p1.ModifyPrice(20f);
	// Set the price.
	p1.ModifyPrice(21f);
