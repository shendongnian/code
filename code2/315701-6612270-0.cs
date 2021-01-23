    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace SendKeyboardInput
    {
        public class SendKey
        {
            [DllImport("user32.dll")]
            public static extern bool SetForegroundWindow(IntPtr hWnd);
            
            public void Send()
            {
                System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName("notepad"); //search for process notepad
                if (p.Length > 0) //check if window was found
                {
                    SetForegroundWindow(p[0].MainWindowHandle); //bring notepad to foreground
                }
                
                SendKeys.SendWait("a"); //send key "a" to notepad
            }
        }
    }
