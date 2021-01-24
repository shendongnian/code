	class SubA : Base
	{
		private int _a;
		public SubA(int a)
		{
			_a = a;
			Init();
		}
		public override void Init()
		{
			//do stuff with int _a
		}
	}
	class SubB : Base
	{
		private string _b;
		public SubB(string b)
		{
			_b = b;
			Init();
		}
		public override void Init()
		{
			//do stuff with string _b
		}
	}
