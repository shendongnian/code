[StructLayout(LayoutKind.Sequential, Pack = 1)]
struct SampleA
{
    public int data1;
    public int data2;
    public unsafe fixed byte data_array[3];
    public int data3;
}
It's more common to embed arrays using `UnmanagedType.ByValArray`:
[StructLayout(LayoutKind.Sequential, Pack = 1)]
struct SampleA
{
    public int data1;
    public int data2;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public byte[] data_array;
    public int data3;
}
If you want to use `char`, you can tell the marshaller that each should be marshalled as a `U8`:
[StructLayout(LayoutKind.Sequential, Pack = 1)]
struct SampleA
{
    public int data1;
    public int data2;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.U8)]
    public char[] data_array;
    public int data3;
}
You can also tell the marshaller that you're using ANSI strings, which has the same effect
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
struct SampleA
{
    public int data1;
    public int data2;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public char[] data_array;
    public int data3;
}
