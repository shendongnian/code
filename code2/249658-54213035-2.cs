	[StructLayout(LayoutKind.Explicit)]
	struct BoolByte
	{
		[FieldOffset(0)]
		public bool flag;
		[FieldOffset(0)]
		public byte num;
	}
	...
	
	bool someBool = true;
	byte num = new BoolByte() { flag = someBool }.num;
