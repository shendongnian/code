[StructLayout(LayoutKind.Sequential, Pack = 1)]
struct SampleA
{
    public int data1;
    public int data2;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public char[] data_array;
    public int data3;
}
