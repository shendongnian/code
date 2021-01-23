	class Program
	{
		static void Main(string[] args)
		{
			MyClass obj = new MyClass()
			              	{
			              		{value1, value2},
			              		{value3, value4}
			              	};
		}
	}
	public class MyClass : IEnumerable
	{
		public void Add(object x, object y)
		{
			
		}
		public IEnumerator GetEnumerator()
		{
		}
	}
