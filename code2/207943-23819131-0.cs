		public SomeClass(int i)
		{
			I = i;
		}
		public SomeClass(SomeOtherClass soc)
			: this(soc.J)
		{
			if (I==0)
			{
				I = DoSomethingHere();
			}
		}
