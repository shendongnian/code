    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FreeImage_OutputMessageFunction(FREE_IMAGE_FORMAT
    format, string msg);
    
    [DllImport(dllName, EntryPoint="FreeImage_SetOutputMessage")]
    public static extern void SetOutputMessage(FreeImage_OutputMessageFunction
    omf);
