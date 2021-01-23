    // Use the static property
    var size = IntPtr.Size;
    // Use Marshal
    var size = System.Runtime.InteropServices.Marshal.SizeOf(typeof(IntPtr));
    // Use unsafe with sizeof
    unsafe
    {
        var size = sizeof(IntPtr);
    }
