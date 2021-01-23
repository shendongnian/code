	interface I
	{
		int X { get; }
	}
	class C : I
	{
		int I.X  // explicit implementation of I.X
		{
			get { return 1; }
			set { }
		}
	}
