	public static class TestModelListExtensions
	{
		public static void Add(this List<TestModel> list, int test1, string test2)
		{
			list.Add(new TestModel { Test1 = test1, Test2 = test2 });  
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			List<TestModel> list = new List<TestModel>();
			list.Add(1, "hello");
		}
	}
