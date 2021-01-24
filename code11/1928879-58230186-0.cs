	interface IA<T> where T : struct
	{
		T? Read(Guid id);
        // Or Nullable<T> Read(Guid id);
	}
	class A : IA<int>
	{
		public int? Read(Guid id) { Console.WriteLine("A"); return 0; }
	}
