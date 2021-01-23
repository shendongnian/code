	public static unsafe void TestInternal(byte* pointer)
	{
		Console.WriteLine((IntPtr)pointer);
	}
	public static void FixedDemo()
	{
		Byte[] newArray = new Byte[1024];
		unsafe
		{
			fixed (Byte* pointer = &newArray[0])
			{
				TestInternal(pointer);
			}
		}
		Console.WriteLine("Test Complete");
	}
