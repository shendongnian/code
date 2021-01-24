    List<ABParent> classesThatAdd()
			{
				new DerivedA(),
				new Derivedb(), 
				new Derived(), 
				new Derived()
			};
    foreach (var item in classesThatAdd)
			{
				item.Add(new object());
			}
