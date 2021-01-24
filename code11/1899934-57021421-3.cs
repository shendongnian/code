        [Guid("21b8916c-f28e-11d2-a473-00c04f8ef448")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IAssemblyEnum
        {
            HRESULT GetNextAssembly(IntPtr pvReserved, out IAssemblyName ppName, int dwFlags);
            HRESULT  Reset();
            HRESULT  Clone(out IAssemblyEnum ppEnum);
        }
        public enum ASM_CACHE_FLAGS
        {
            ASM_CACHE_ZAP = 0x01,
            ASM_CACHE_GAC = 0x02,
            ASM_CACHE_DOWNLOAD = 0x04,
            ASM_CACHE_ROOT = 0x08,
            ASM_CACHE_ROOT_EX = 0x80
        }
        [DllImport("Fusion.dll", SetLastError = true)]
        public static extern HRESULT CreateAssemblyEnum(out IAssemblyEnum pEnum, IntPtr pUnkReserved, IAssemblyName pName, ASM_CACHE_FLAGS dwFlags, IntPtr pvReserved);
        [Guid("CD193BC0-B4BC-11d2-9833-00C04FC31D2E")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IAssemblyName
        {
            HRESULT SetProperty(int PropertyId, IntPtr pvProperty, int cbProperty);
            HRESULT GetProperty(int PropertyId,  out IntPtr pvProperty, ref int pcbProperty);
            HRESULT Finalize();
            HRESULT GetDisplayName(StringBuilder szDisplayName,  ref int pccDisplayName, ASM_DISPLAY_FLAGS dwDisplayFlags);
            HRESULT Reserved([In, MarshalAs(UnmanagedType.LPStruct)] Guid refIID, IntPtr pUnkReserved1, IntPtr pUnkReserved2, string szReserved, UInt64 llReserved,  IntPtr pvReserved, int cbReserved, out IntPtr ppReserved);
            HRESULT GetName(ref  int lpcwBuffer, StringBuilder pwzName);
            HRESULT GetVersion(out int pdwVersionHi, out int pdwVersionLow);
            HRESULT IsEqual(IAssemblyName pName, int dwCmpFlags);
            HRESULT Clone(out IAssemblyName pName);
        }
        public enum ASM_DISPLAY_FLAGS
        {
            ASM_DISPLAYF_VERSION = 0x1,
            ASM_DISPLAYF_CULTURE = 0x2,
            ASM_DISPLAYF_PUBLIC_KEY_TOKEN = 0x4,
            ASM_DISPLAYF_PUBLIC_KEY = 0x8,
            ASM_DISPLAYF_CUSTOM = 0x10,
            ASM_DISPLAYF_PROCESSORARCHITECTURE = 0x20,
            ASM_DISPLAYF_LANGUAGEID = 0x40,
            ASM_DISPLAYF_RETARGET = 0x80,
            ASM_DISPLAYF_CONFIG_MASK = 0x100,
            ASM_DISPLAYF_MVID = 0x200,
            ASM_DISPLAYF_CONTENT_TYPE = 0x400,
            ASM_DISPLAYF_FULL = (((((ASM_DISPLAYF_VERSION | ASM_DISPLAYF_CULTURE) | ASM_DISPLAYF_PUBLIC_KEY_TOKEN) | ASM_DISPLAYF_RETARGET) | ASM_DISPLAYF_PROCESSORARCHITECTURE) | ASM_DISPLAYF_CONTENT_TYPE)
        }        
 
        [DllImport("Fusion.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern HRESULT CreateAssemblyNameObject(out IAssemblyName ppAssemblyNameObj, [MarshalAs(UnmanagedType.LPWStr)] string szAssemblyName, CREATE_ASM_NAME_OBJ_FLAGS flags,  IntPtr pvReserved);
        public enum CREATE_ASM_NAME_OBJ_FLAGS
        {
            CANOF_PARSE_DISPLAY_NAME = 0x1,
            CANOF_SET_DEFAULT_VALUES = 0x2,
            CANOF_VERIFY_FRIEND_ASSEMBLYNAME = 0x4,
            CANOF_PARSE_FRIEND_DISPLAY_NAME = (CANOF_PARSE_DISPLAY_NAME | CANOF_VERIFY_FRIEND_ASSEMBLYNAME)
        }
