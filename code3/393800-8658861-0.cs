    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void rdOnAllDoneCallbackDelegate(int parameter);
    
    [DllImport("sb6lib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int rdOnAllDone(rdOnAllDoneCallbackDelegate d);
    class Foo {
        private static rdOnAllDoneCallbackDelegate callback;   // Keeps it referenced
        public static void SetupCallback() {
           callback = new rdOnAllDoneCallbackDelegate(rdOnAllDoneCallback);
           rdOnAllDone(callback);
        }
        private static void rdOnAllDoneCallback(int parameter) {
           Console.WriteLine("rdOnAllDoneCallback invoked, parameter={0}", parameter);
        }
    }
