    [ComImport]
    [Guid("EFBF7D84-3EFE-41E0-952E-68A44A3E72CA")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface MyInterface
    {
        [PreserveSig] double GetValue();
        void ThrowError();
    }
    class Program
    {
        [DllImport("mylib.dll")]
        static extern MyInterface CreateInstance();
        static void Main(string[] args)
        {
            MyInterface iface = CreateInstance();
            Console.WriteLine(iface.GetValue());
            try { iface.ThrowError(); }
            catch(Exception ex) { Console.WriteLine(ex); }
            Console.ReadKey(true);
        }
    }
