    using System;
    using System.Runtime.InteropServices;
    
    namespace Test { class TestApp {
    public class WinApi
    {
      public const int CSIDL_APPDATA = 0x1a;
      public const int SHGFP_TYPE_DEFAULT = 1;
      [DllImport("shell32.dll")]
      public static extern int SHGetFolderPath(IntPtr hwnd, int csidl, IntPtr hToken, uint flags, [Out] System.Text.StringBuilder Path);
    }
    
    [STAThread]
    static void Main() 
    {
      System.Text.StringBuilder builder = new System.Text.StringBuilder(260);
      int result = WinApi.SHGetFolderPath(IntPtr.Zero, WinApi.CSIDL_APPDATA, IntPtr.Zero, WinApi.SHGFP_TYPE_DEFAULT, builder);
      string path = "";
      if (result == 0) path = builder.ToString();
      Console.WriteLine(string.Format("{0}:{1}", result, path));
    }
    } }
