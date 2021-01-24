	class Program
	{
		static void Create()
		{
			Customer[] customers =
			{
				new Customer (),
				new Customer (),
				new Customer (),
			};
		}
		static void Main(string[] args)
		{
			Create();
			Console.WriteLine($"Before GC Count: {Customer.InstanceCount}");
			GC.Collect(0);
			GC.WaitForPendingFinalizers();
			Console.WriteLine($"After GC Count: {Customer.InstanceCount}");
		}
	}
