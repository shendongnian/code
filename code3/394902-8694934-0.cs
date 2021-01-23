    using System.Runtime.InteropServices;
    
        // ... 
           public class MyWindowHandling {
    
           private const int WM_CLOSE = 0x0010;
           [DllImport("user32", CharSet = CharSet.Unicode)]
            private static extern
            IntPtr FindWindow(
                    string lpClassName,
                    string lpWindowName
            );
        
           [DllImport("user32")]
            private static extern
            IntPtr SendMessage(
                    IntPtr handle,
                    int Msg,
                    IntPtr wParam,
                    IntPtr lParam
             );
    
             public void CloseWindowByClassName(string className) {
                 IntPtr handle = FindWindow(null, className);
                  if (handle != IntPtr.Zero) {
                       SendMessage(handle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                   }
            }
          }
