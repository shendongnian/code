    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct MyStruct
    {
       [StructLayout(LayoutKind.Sequential, Pack = 1, Size=10)]
       public struct Field2e__FixedBuffer0
    	{
    	    public sbyte FixedElementField;
    	}
       public UInt32 Field1;
       public Field2e__FixedBuffer0 Field2;
       public UInt64 Field3;
    }
