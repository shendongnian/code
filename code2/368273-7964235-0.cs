    using System.Runtime.InteropServices;
    [StructLayout(LayoutKind.Explicit)]
    struct ByteArray {
      [FieldOffset(0)]
      public byte Byte1;
      [FieldOffset(0)]
      public int Int1;
      [FieldOffset(0)]
      public int Int2;
    }
