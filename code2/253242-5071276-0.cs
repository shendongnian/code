    [DllImport("Interop.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void Foo( int i  );
    
    private void Test()
    {
        Foo( 1 );
    }
