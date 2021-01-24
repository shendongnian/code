      // need a static class to contain the definitions of the managed
      // equivalent of function pointers, which are delegates
      static class Native
      {
        // assuming you are using these as callbacks, the Marshaler needs to know
        // how to fix up the call stack
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ulong LoopConvertFunc([MarshalAs(UnmanagedType.Struct)]conv_struct icd,
                                              ref StringBuilder inbuf,
                                              ref ulong inbytesLeft,
                                              ref StringBuilder outbuf,
                                              ref ulong outbytesLeft);
    
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ulong LoopResetFunc([MarshalAs(UnmanagedType.Struct)]conv_struct icd, ref StringBuilder outbuf, ref ulong outbytesLeft);
      }
    
      [StructLayout(LayoutKind.Sequential)]
      struct loop_funcs
      {
        Native.LoopConvertFunc loop_convert;
        Native.LoopResetFunc loop_reset;
      }
