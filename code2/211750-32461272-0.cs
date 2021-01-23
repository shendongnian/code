    bool IsPositive(int number)
    {
       bool result = false;
       IntPtr memory = IntPtr.Zero;
       try
       {
           memory = Marshal.AllocHGlobal(4);
           if (memory == IntPtr.Zero)
               throw new OutOfMemoryException();
           Marshal.WriteInt32(memory, number);
           
           result = Marshal.ReadByte(memory, 3) & 0x80 == 0;
       }
       finally
       {
           if (memory != IntPtr.Zero)
               Marshal.FreeHGlobal(memory);
       }
    }
