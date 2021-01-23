	private static int __counter = 0;
		
	public class Data
	{
		public int X { set; get; }
		public int Y { set; get; }
		public int Result { set; get; }
	}
	
	private void Addition(Data data)
	{
		data.Result = data.X + data.Y;
		Interlocked.Increment(ref __counter);
	
		Thread.Sleep(1000);
		
		Console.WriteLine(data.Result);
		Console.WriteLine("End of thread");
	}
