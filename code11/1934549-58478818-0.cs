    public class WinApi
    {
    public enum INTERNET_OPTION : uint { PROXY = 38 }
    
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct INTERNET_PROXY_INFOA
    {
    	public IntPtr accessType;
    	public string proxy;
    	public string proxyBypass;
    }
    
    [DllImport("wininet.dll", SetLastError = true)]
    public static extern int InternetQueryOptionA([In] IntPtr hInternet, [In] INTERNET_OPTION option, [In, Out] IntPtr buffer, [In, Out] ref int bufferSize);
    
    }
