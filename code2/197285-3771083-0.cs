    class MyClass
    {
        [DllImport("someUnmanagedDll.dll")]
        static extern int UnManagedCodeMethod(string msg, string title);
        public static void Main() 
        {
            UnManagedCodeMethod("calling unmanaged code", "hi");
        }
    }
