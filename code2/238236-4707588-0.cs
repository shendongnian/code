    public static DateTime ToDateTime( System.Runtime.InteropServices.FILETIME ft )
    {
      IntPtr buf = IntPtr.Zero;
      try 
      {
        long[] longArray = new long[1];
        int cb = Marshal.SizeOf( ft );
        buf = Marshal.AllocHGlobal( cb );
        Marshal.StructureToPtr( ft, buf, false );
        Marshal.Copy( buf, longArray, 0, 1 );
        return DateTime.FromFileTime( longArray[0] );
      }
      finally 
      {
        if ( buf != IntPtr.Zero ) Marshal.FreeHGlobal( buf );
      }
    }
