	Animal animal = new Dog();
	{ // <-- scopes the existence of critter to this block
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
