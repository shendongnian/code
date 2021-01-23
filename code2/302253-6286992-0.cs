    public static class InternetSecurityManager
    {
        private static Guid _CLSID_SecurityManager = new Guid("7b8a2d94-0ac9-11d1-896c-00c04fb6bfc4");
        private static string[] ZoneNames = new[] { "Local", "Intranet", "Trusted", "Internet", "Restricted" };
        public static string GetUrlZone(string url)
        {
            Type t = System.Type.GetTypeFromCLSID(_CLSID_SecurityManager);
            IInternetSecurityManager securityManager = (IInternetSecurityManager)System.Activator.CreateInstance(t);
            try
            {
                uint zone = 0;
                int hResult = securityManager.MapUrlToZone(url, ref zone, 0);
                if (hResult != 0)
                    throw new COMException("Error calling MapUrlToZone, HRESULT = " + hResult.ToString("x"), hResult);
                if (zone < ZoneNames.Length)
                    return ZoneNames[zone];
                return "Unknown - " + zone;
            }
            finally
            {
                Marshal.ReleaseComObject(securityManager);
            }
        }
    }
    [ComImport, GuidAttribute("79EAC9EE-BAF9-11CE-8C82-00AA004BA90B")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInternetSecurityManager
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetSecuritySite([In] IntPtr pSite);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetSecuritySite([Out] IntPtr pSite);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int MapUrlToZone([In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
                 ref UInt32 pdwZone, UInt32 dwFlags);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetSecurityId([MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
                  [MarshalAs(UnmanagedType.LPArray)] byte[] pbSecurityId,
                  ref UInt32 pcbSecurityId, uint dwReserved);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ProcessUrlAction([In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
                 UInt32 dwAction, out byte pPolicy, UInt32 cbPolicy,
                 byte pContext, UInt32 cbContext, UInt32 dwFlags,
                 UInt32 dwReserved);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int QueryCustomPolicy([In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
                  ref Guid guidKey, ref byte ppPolicy, ref UInt32 pcbPolicy,
                  ref byte pContext, UInt32 cbContext, UInt32 dwReserved);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetZoneMapping(UInt32 dwZone,
                   [In, MarshalAs(UnmanagedType.LPWStr)] string lpszPattern,
                   UInt32 dwFlags);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetZoneMappings(UInt32 dwZone, out UCOMIEnumString ppenumString,
                UInt32 dwFlags);
    }
   
