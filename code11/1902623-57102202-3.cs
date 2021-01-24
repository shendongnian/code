`
const short SP_PACKET_SIZE = 200;
const short NAME_SIZE = 64;
struct spPacketStruct
{
  public int Size;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = SP_PACKET_SIZE)]
  private fixedString[] names;
  public fixedString[] Names { get { return names ?? (names = new fixedString[SP_PACKET_SIZE]); } }
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = SP_PACKET_SIZE)]
  private double[] value;
  public double[] Value { get { return value ?? (value = new double[SP_PACKET_SIZE]); } }
}
struct fixedString
{
  [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NAME_SIZE)]
  public string Name;
}
`
By having additional struct to be a member of the original struct, you are able to specify the length of both dimensions by setting `SizeConst` in the original struct to the first dimension and setting it to the second dimension in the new struct. Making the field private and creating properties for them is merely for convenience, so you don't have to assign the array yourself when creating the struct.  
Then you can serialize/deserialize the struct like this (code from this answer: https://stackoverflow.com/a/35717498/9748260):
`
public static byte[] GetBytes<T>(T str)
{
  int size = Marshal.SizeOf(str);
  byte[] arr = new byte[size];
  GCHandle h = default;
  try
  {
    h = GCHandle.Alloc(arr, GCHandleType.Pinned);
    Marshal.StructureToPtr(str, h.AddrOfPinnedObject(), false);
  }
  finally
  {
    if (h.IsAllocated)
    {
      h.Free();
    }
  }
  return arr;
}
public static T FromBytes<T>(byte[] arr) where T : struct
{
  T str = default;
  GCHandle h = default;
  try
  {
    h = GCHandle.Alloc(arr, GCHandleType.Pinned);
    str = Marshal.PtrToStructure<T>(h.AddrOfPinnedObject());
  }
  finally
  {
    if (h.IsAllocated)
    {
      h.Free();
    }
  }
  return str;
}
`
And one last thing when trying to serialize/deserialize structs like this, be aware of the struct alignment as it can mess with the struct size
