    List<FooBar> bars = new List<FooBar>()
		{
			new FooBar() //end date is inside 3
			{
				Start = new DateTime(2001,12,1),
				End = new DateTime(2002,5,15),
				Id = 1
			},
			new FooBar() //fine
			{
				Start = new DateTime(2005,12,1),
				End = new DateTime(2006,5,15),
				Id = 2
			},
			new FooBar() //start date is inside 1
			{
				Start = new DateTime(2002,4,1),
				End = new DateTime(2003,5,15),
				Id = 3
			},
			new FooBar() //this one is fine
			{
				Start = new DateTime(2006,5,15),
				End = new DateTime(2007,5,15),
				Id = 4
			},
			new FooBar() //also fine
			{
				Start = new DateTime(2001,12,1),
				End = new DateTime(2001,12,1),
				Id = 5
			},
		};
