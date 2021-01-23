    class Program
    {
        public Program()
        {
            GetOpenedFiles("C:\\", OF_TYPE.ALL_TYPES, CallbackFunction, UIntPtr.Zero);
            Console.ReadKey();
        }
    
        //void GetOpenedFiles(LPCWSTR lpPath, OF_TYPE Filter, OF_CALLBACK CallBackProc, UINT_PTR pUserContext);
    
        public enum OF_TYPE : int
        {
            FILES_ONLY = 1,
            MODULES_ONLY = 2,
            ALL_TYPES = 3
        }
    
        [StructLayout(LayoutKind.Sequential,CharSet = CharSet.Unicode)]
        public struct OF_INFO_t
        {
            public Int32 dwPID;
            public String lpFile;
            public IntPtr hFile;
        }
    
        public delegate void CallbackFunctionDef(OF_INFO_t info, IntPtr context);
    
        [DllImport("OpenFileFinder.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "GetOpenedFiles")]
        static extern void GetOpenedFiles(string lpPath, OF_TYPE filter, CallbackFunctionDef CallBackProc, UIntPtr pUserContext);
    
        public void CallbackFunction(OF_INFO_t info, IntPtr context)
        {
            //List the files
            Console.WriteLine(info.lpFile);
        }
    
        [STAThread]
        static void Main()
        {
            new Program();
        }
    }
