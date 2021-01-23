    static class Class    
    {
        [DllImport("Kernel32.dll")]
        static extern Boolean Beep(UInt32 frequency, UInt32 duration);
    
        public static void methodRequiringStuffFromKernel32()
        {
            // code here...
            Beep(...);
        }
    }
