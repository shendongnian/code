    public enum AGSReturnCode
    {
        AGS_ERROR_MISSING_DLL = -2,
        AGS_ERROR_LEGACY_DRIVER = -1,
        AGS_FAILURE = 0,
        AGS_SUCCESS = 1
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct AGSDriverVersionInfoStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string strDriverVersion;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string strCatalystVersion;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string strCatalystWebLink;
    }
    public static class AGSharp
    {
        [DllImport("atiags.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "agsDriverGetVersionInfo")]
        public static extern AGSReturnCode agsDriverGetVersionInfo(out AGSDriverVersionInfoStruct driver_info);
    }
