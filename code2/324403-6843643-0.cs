    public struct OF_INFO_t
    {
       Int32 dwPID;
       String lpFile;
       IntPtr hFile;
    }
    public delegate void CallbackFunctionDef(OF_INFO_t info, IntPtr context);
    [DllImport("OpenFileFinder.dll", EntryPoint = "GetOpenedFiles")]
    static extern void GetOpenedFiles(string lpPath, OF_TYPE filter, CallbackFunctionDef CallBackProc, UIntPtr pUserContext
