	public void Test()
	{
		var animals = new Animal[] { new Dog(), new Duck() };
		foreach (var animal in animals)
		{
			{	// <-- scopes the existence of critter to this block
				Dog critter;
				if (null != (critter = animal as Dog))
				{
					critter.Name = "Scopey";
					// ...
				}
			}
			{
				Duck critter;
				if (null != (critter = animal as Duck))
				{
					critter.Fly();
					// ...
				}
			}
		}
	}
