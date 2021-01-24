public class Program
{
	public class A
	{
		private readonly object pixelsLock = new object();
		Array shared = ...;
		public void Method2()
		{
			Array myPixels = (...);
			while (true)
			{
				// Prepare image
				BitmapFrame bf = BitmapFrame.Create(screen);
				RenderOptions.SetBitmapScalingMode(bf, BitmapScalingMode.LowQuality);
				bf.CopyPixels(new Int32Rect(0, 0, width, height), myPixels, width * 4, 0);
				lock (pixelsLock)
				{
					// Copy the hard work to shared storage
					Array.Copy(sourceArray: myPixels, destinationArray: shared, length: myPixels.GetUpperBound(0) - 1);
				}
			}
		}
		public void Method1()
		{
			Array myPixels = (...);
			while (true)
			{
				lock (pixelsLock)
				{
					//Max a local copy
					Array.Copy(sourceArray: shared, destinationArray: myPixels, length: myPixels.GetUpperBound(0) - 1);
				}
				DisplayWrapper.USBD480_DrawFullScreenBGRA32(ref disp, myPixels);
			}
		}
	}
	public static async Task Main(string[] args)
	{
		var a = new A();
		new Thread(new ThreadStart(a.Method1)).Start();
		new Thread(new ThreadStart(a.Method2)).Start();
		Console.ReadLine();
	}
}
