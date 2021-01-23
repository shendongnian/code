    using System;
    using System.Runtime.InteropServices;
    
    class MsgBoxTest
    {
      [DllImport("user32.dll")]
      static extern int MessageBox (IntPtr hWnd, string text, string caption,
                                    int type);
      public static void Main()
      {
        MessageBox (IntPtr.Zero, "Please do not press this again.", "Attention", 0);
      }
    }
