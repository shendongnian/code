    [StructLayout(LayoutKind.Explicit)]
    public struct COMMAND_GET
    {
    	[FieldOffset(0)]
    	public byte CommandID;
    	[FieldOffset(1)]
    	public byte PacketID;
    	[FieldOffset(2)]
    	public byte GetID;
    	[FieldOffset(3)]
    	[MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
    	public byte[] RFU;
    	[FieldOffset(6)]
    	public ADC_Data Adc_data;
    	[FieldOffset(6)]
    	public SomeOther_Data other_data;
    	[FieldOffset(6)]
    	....
    }
    
    
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct ADC_Data
    {
    	public short Supply;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
    	public short[] Current;
    }
