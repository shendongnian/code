    public static unsafe void Main(string[] args)
	{
        // Dummy pointer, never dereferenced
	    byte* testPtr = (byte*)0x00000008000000L;
		uint offset = uint.MaxValue;
		unchecked
		{
			Console.WriteLine("{0:x}", (long)(testPtr + offset));
		}
		checked
		{
			Console.WriteLine("{0:x}", (long)(testPtr + offset));
		}
		unchecked
		{
			Console.WriteLine("{0:x}", (long)(testPtr + (long)offset));
		}
		checked
		{
			Console.WriteLine("{0:x}", (long)(testPtr + (long)offset));
		}
	}
