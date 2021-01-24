	class Program
	{
		static void Main(string[] args)
		{
			List<TestBase> lstTest = new List<TestBase>();
			lstTest.Add(new Test { Name = "j", Score = 2 });
			lstTest.Add(new Test2 { Name = "p", Score = 3 });
		}
	}
	class TestBase
	{
		private string name;
		private int score;
		public string Name
		{
			get { return name;  }
			set { this.name = value; }
		}
		public int Score
		{
			get { return score; }
			set { this.score = value; }
		}
	}
	class Test : TestBase { }
	class Test2 : TestBase { }
