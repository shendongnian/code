    public sealed class SafeStrCmpLogical : SafeNativeMethod
    {
        public SafeStrCmpLogical()
            : base("shlwapi.dll", "StrCmpLogicalW")
        {        	
        }
        public int Invoke(string psz1, string psz2)
        {
            return CanInvoke ? StrCmpLogicalW(psz1, psz2) : 0;
        }
        [DllImport("shlwapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern int StrCmpLogicalW(string psz1, string psz2);
    }
    public sealed class SafeDwmIsCompositionEnabled : SafeNativeMethod
    {
        public SafeDwmIsCompositionEnabled()
            : base("dwmapi.dll", "DwmIsCompositionEnabled")
        {
        }
        public bool Invoke()
        {
            return CanInvoke ? DwmIsCompositionEnabled() : false;
        }
        [DllImport("dwmapi.dll", SetLastError = true, PreserveSig = false)]
        private static extern bool DwmIsCompositionEnabled();
    }
