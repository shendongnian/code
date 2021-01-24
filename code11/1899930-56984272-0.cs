    Console.WriteLine(GetAssemblyPath("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
    // dumps C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll
    ...
    public static string GetAssemblyPath(string name, bool matchClrVersion = true, bool throwOnError = false)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));
        string finalName = name;
        var aInfo = new ASSEMBLY_INFO();
        aInfo.cchBuf = 1024;
        aInfo.pszCurrentAssemblyPathBuf = new string('\0', aInfo.cchBuf);
        var hr = CreateAssemblyCache(out IAssemblyCache ac, 0);
        if (hr >= 0)
        {
            hr = ac.QueryAssemblyInfo(0, finalName, ref aInfo);
            if (hr < 0 && matchClrVersion)
            {
                var asmName = new AssemblyName(name);
                finalName = asmName.Name + ", Version=" + Environment.Version.Major + "." + Environment.Version.Minor;
                aInfo.pszCurrentAssemblyPathBuf = new string('\0', aInfo.cchBuf);
                hr = ac.QueryAssemblyInfo(0, finalName, ref aInfo);
            }
        }
        if (hr < 0)
        {
            if (throwOnError)
                Marshal.ThrowExceptionForHR(hr);
            return null;
        }
        return aInfo.pszCurrentAssemblyPathBuf;
    }
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("e707dcde-d1cd-11d2-bab9-00c04f8eceae")]
    private interface IAssemblyCache
    {
        void UninstallAssembly(); // not fully defined
        [PreserveSig]
        int QueryAssemblyInfo(int flags, [MarshalAs(UnmanagedType.LPWStr)] string assemblyName, ref ASSEMBLY_INFO assemblyInfo);
    }
    [StructLayout(LayoutKind.Sequential)]
    private struct ASSEMBLY_INFO
    {
        public int cbAssemblyInfo;
        public int dwAssemblyFlags;
        public long uliAssemblySizeInKB;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszCurrentAssemblyPathBuf;
        public int cchBuf;
    }
    [DllImport("fusion")]
    private static extern int CreateAssemblyCache(out IAssemblyCache ppAsmCache, int reserved);
