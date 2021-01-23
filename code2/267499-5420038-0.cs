	void Main()
	{
		unsafe
		{
			var inst = new TestClass();
			byte* test = stackalloc byte[5];
			
			uint count;
			inst.Test(test, &count);
		}
		unsafe
		{
			dynamic inst = new TestClass();
			byte* test = stackalloc byte[5];
			
			uint count;
			inst.Test(new IntPtr(test), new IntPtr(&count));
		}	
	}
	class TestClass
	{
		public unsafe void Test(IntPtr buffer, IntPtr count)
		{
			Test((byte*)buffer.ToPointer(), (uint*)count.ToPointer());
		}
		public unsafe void Test(byte* buffer, uint* count)
		{
		}
	}
