    [DllImport("xfoilapi.dll")]
    public static extern IntPtr GetXfoilResults();
    [StructLayout(LayoutKind.Sequential)]
    public class XfoilResults
    {
        IntPtr pAlfa;
        IntPtr pCL;
        IntPtr pCM;
        IntPtr pCDi;
        IntPtr pCDo;
        IntPtr pCPmax;
        int nEntries; // thanks to guys for reminding me long is 4 bytes
    }
    XfoilResults xf  ==  new XfoilResults();
    Marshal.PtrToStructure(GetXfoilResults(), xf);
