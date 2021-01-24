class Program
	{
		static void Main(string[] args)
		{
			CallContext.LogicalSetData("rollbackGuid", Guid.NewGuid());
			Test();
			Console.ReadKey();
		}
		public static void Test()
		{
			Test1();
		}
		//[RetryOnExceptionAttribute]
		public static void Test1()
		{
			Test2();
		}
		public static void Test2()
		{
			Test3();
		}
		public static void Test3()
		{
			Console.WriteLine($"Current thread id: {Thread.CurrentThread.ManagedThreadId}");
			Task.Run((() => { Test4(); }));
		}
		public static void Test4()
		{
			Console.WriteLine($"Current thread id: {Thread.CurrentThread.ManagedThreadId}");
			Console.WriteLine($"Rollback guid: {Rollback.CurrentGuid}");
		}
	}
	static class Rollback
	{
		public static Guid CurrentGuid => (Guid)CallContext.GetData("rollbackGuid");
	}
