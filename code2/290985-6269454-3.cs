	[TestMethod]
	[HostType("Moles")]
	public void Test1()
	{
		// Call a constructor that sets the price to 10.
		var fake = new SProduct { CallBase = true };
		var mole = new MProduct(fake)
		{
			ModifyPriceSingle = actual =>
			{
				if (actual != 20.0f)
				{
					MolesContext.ExecuteWithoutMoles(() => fake.ModifyPrice(actual));
				}
				else
				{
					Debug.WriteLine("Skipped setting price.");
				}
			}
		};
		fake.ModifyPrice(20f);
		fake.ModifyPrice(21f);
	}
