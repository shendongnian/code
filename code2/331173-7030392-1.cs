    unsafe struct ExampleClass
    {
       public ulong field1;
       public uint field2
       public ushort field3
       public fixed byte field4[18];
       public static ExampleClass ReadStruct(byte[] data)
       {
           fixed (byte* pb = &data[0])
           {
               return *(ExampleClass*)pb;
           }
       }
    }
