	public class ProcessBassTypeClass : IProcessBaseType
	{
		public void Process(BaseTypeClass data)
		{
			Console.WriteLine("Processing as BaseTypeClass");
		}
		public void Process<T>(T data)
		{
			Console.WriteLine("Processing as generic with T = {0}", typeof(T).Name);
		}
	}
